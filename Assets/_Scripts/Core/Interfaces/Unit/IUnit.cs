using UnityEngine;

namespace DungeonDivers.Core.Interfaces.Unit
{
    public interface IUnit
    {
        public string UnitName { get; }
        public string UnitDescription { get; }
        public Sprite UnitIcon { get; }
        public GameObject GameObject { get; }
    }
}
