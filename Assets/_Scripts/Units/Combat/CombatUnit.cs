using DungeonDivers.Core.Interfaces.Card;
using DungeonDivers.Core.Interfaces.Unit;
using UnityEngine;

namespace DungeonDivers.Units
{
    [RequireComponent(typeof(BaseUnit), typeof(IHealth), typeof(ITargetable))]
    public class CombatUnit : MonoBehaviour, ICombatUnit
    {
        private IHealth health;
        private BaseUnit baseUnit;
        private ITargetable targetable;

        public IHealth Health => health;

        public IUnit BaseUnit => baseUnit;

        public ITargetable TargetableUnit => targetable;

        public void Awake()
        {
            health = GetComponent<IHealth>();
            baseUnit = GetComponent<BaseUnit>();
            targetable = GetComponent<ITargetable>();

            // TESTING PURPOSES ONLY
            this.Health.SetMaxHealth(100);
            this.Health.SetCurrentHealth(this.Health.MaxHealth);
        }

    }
}
