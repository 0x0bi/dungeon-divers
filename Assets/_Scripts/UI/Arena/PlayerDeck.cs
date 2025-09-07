using System;
using System.Collections.Generic;
using System.Linq;
using DungeonDivers.Arena;
using DungeonDivers.Card;
using DungeonDivers.Core.Interfaces.Card;
using NUnit.Framework.Constraints;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerDeck : MonoBehaviour
{
    [Header("Imports")]
    [SerializeField] private ArenaContext context;
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private CanvasGroup cardsParent;
    [SerializeField] private PlayerUnitController playerController;
    [SerializeField] private Canvas canvas;

    [Header("Prefabs")]
    [SerializeField] private CardUI cardUIPrefab;

    private Spline spline => splineContainer.Spline;
    private List<CardUI> cardsUI = new();


    public void OnChangeCurrentState(bool isActive)
    {
        cardsParent.alpha = isActive ? 1 : 0;
        cardsParent.blocksRaycasts = isActive;
        cardsParent.interactable = isActive;
    }

    public void OnHandChange()
    {
        ResetCardDeck();
        int i = 0;
        foreach (string index in playerController.CurrentHand.Keys)
        {
            ICard card = playerController.CurrentHand[index];
            AddCardUI(Vector2.zero, Quaternion.identity, index, card, i);
            RefreshCardDeck();
            i++;
        }
    }

    private void ResetCardDeck()
    {
        foreach (CardUI cui in cardsUI)
        {
            Destroy(cui.gameObject);
        }
        cardsUI = new();
    }

    private void RefreshCardDeck()
    {
        if (cardsUI.Count == 0)
        {
            return;
        }

        float cardSpacing = 1f / cardsUI.Count;
        float firstCardPos = 0.5f - (cardsUI.Count - 1) * cardSpacing / 2;
        for (int i = 0; i < cardsUI.Count; i++)
        {
            float p = firstCardPos + i * cardSpacing;
            Vector3 splinePos = spline.EvaluatePosition(p);
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(up, Vector3.Cross(up, forward).normalized);
            UpdateCardUI(splinePos, rotation, cardsUI[i]);
        }
    }

    private void UpdateCardUI(Vector3 splinePos, Quaternion rotation, CardUI cardUI)
    {
        cardUI.SetPositionAndRotation(WorldToCanvasPosition(splinePos), rotation);
        cardUI.UpdateBasePosition();

    }

    private CardUI AddCardUI(Vector2 pos, Quaternion rotation, string id, ICard card, int index)
    {
        CardUI instantiatedObj = Instantiate(cardUIPrefab, Camera.main.WorldToViewportPoint(pos), rotation, cardsParent.transform);
        instantiatedObj.SetCard(card as BaseCard, id, index, this, canvas);
        cardsUI.Add(instantiatedObj);
        return instantiatedObj;
    }

    internal void SwapCards(CardUI current, CardUI other)
    {

        cardsUI[other.Index] = current;
        cardsUI[current.Index] = other;

        int tmp = other.Index;
        other.ChangeIndex(current.Index);
        current.ChangeIndex(tmp);

        RefreshCardDeck();
    }

    private Vector2 WorldToCanvasPosition(Vector3 worldPosition)
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(worldPosition);

        Vector2 canvasPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            screenPoint,
            null,
            out canvasPosition
        );

        return canvasPosition;
    }
}
