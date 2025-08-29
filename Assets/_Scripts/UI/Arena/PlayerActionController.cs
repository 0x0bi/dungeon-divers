using System;
using DungeonDivers.Arena;
using NUnit.Framework;
using UnityEngine;

public class PlayerActionController : MonoBehaviour
{
    [SerializeField] private CanvasGroup group;

    public void OnIsPlayerTurn(bool active)
    {
        if (!active)
        {
            DisableGroup();
            return;
        }
        EnableGroup();
    }

    private void DisableGroup()
    {
        group.alpha = 0;
        group.interactable = false;
    }

    private void EnableGroup()
    {
        group.alpha = 1;
        group.interactable = true;
    }
}
