using System;
using System.Collections.Generic;
using DungeonDivers.Card;
using DungeonDivers.Core.Interfaces.Card;
using DungeonDivers.Core.Interfaces.Unit;
using DungeonDivers.Core.Structs.Arena;
using TMPro;
using TreeEditor;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CardUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField][Range(0, 2)] private float raiseFactor;

    private BaseCard card;
    private string id;
    private int index;
    private ITargetable currentTarget;
    private PlayerDeck deckUIController;
    private Canvas canvas;


    public string ID => id;
    public int Index => index;
    public bool isProcessing { get; private set; } = false;

    private Quaternion baseRotation;
    private Vector3 basePosition;
    public void SetCard(BaseCard _card, string _id, int _index, PlayerDeck _deckUIController, Canvas _canvas)
    {
        card = _card;
        id = _id;
        index = _index;
        canvas = _canvas;
        deckUIController = _deckUIController;
        RefreshCardUIData();
    }

    public void Awake()
    {
        UpdateBasePosition();
    }
    public void UpdateBasePosition()
    {
        baseRotation = transform.rotation;
        basePosition = transform.position;
    }

    private void ResetToBasePosition()
    {
        transform.SetPositionAndRotation(basePosition, baseRotation);
    }

    private void RefreshCardUIData()
    {
        text.text = card.CardName;
    }

    #region Mouse Event Handlers
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        isProcessing = false;

        ResetToBasePosition();

    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.85f;
        canvasGroup.blocksRaycasts = false;
        isProcessing = true;
        transform.SetAsLastSibling();
        transform.rotation = quaternion.identity;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;
        if (!eventData.pointerDrag.TryGetComponent(out CardUI other)) return;
        if (other.ID == this.ID || other.Index == this.index) return;
        this.deckUIController.SwapCards(this, other);
    }

    #endregion
    internal void ChangeIndex(int _index)
    {
        index = _index;
    }

    internal void SetPositionAndRotation(Vector3 splinePos, Quaternion rotation)
    {
        rectTransform.anchoredPosition = splinePos;
        rectTransform.rotation = rotation;
    }

    public void OnSelect(ICombatUnit caster, ICombatUnit enemies)
    {
        throw new NotImplementedException();
    }

    public void OnUse(ArenaTurnData turn)
    {
        throw new NotImplementedException();
    }
}

