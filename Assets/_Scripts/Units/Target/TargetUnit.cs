using System;
using DungeonDivers.Core.Interfaces.Unit;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DungeonDivers.Units
{
    [RequireComponent(typeof(Collider2D))]
    public class TargetUnit : MonoBehaviour, ITargetable
    {
        public event EventHandler OnTargetClicked;
        public event EventHandler<PointerEventData> OnDropOnTarget;
        public bool IsEnabled { get; private set; } = false;
        public void DisableTarget()
        {
            IsEnabled = false;
        }

        public void EnableTarget()
        {
            IsEnabled = true;
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("Something");
            OnDropOnTarget.Invoke(this, eventData);
        }
    }
}
