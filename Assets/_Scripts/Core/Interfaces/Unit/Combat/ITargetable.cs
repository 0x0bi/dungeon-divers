using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DungeonDivers.Core.Interfaces.Unit
{
    public interface ITargetable : IDropHandler
    {
        public void EnableTarget();
        public void DisableTarget();

        public event EventHandler OnTargetClicked;
        public event EventHandler<PointerEventData> OnDropOnTarget;
    }

}
