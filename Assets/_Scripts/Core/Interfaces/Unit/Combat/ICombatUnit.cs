using UnityEngine;

namespace DungeonDivers.Core.Interfaces.Unit
{
    public interface ICombatUnit
    {
        public IHealth Health { get; }
        public IUnit BaseUnit { get; }
        public ITargetable TargetableUnit { get; }
    }
}
