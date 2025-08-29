using DungeonDivers.Core.Interfaces.Unit;
using UnityEngine;

namespace DungeonDivers.Units
{
    [RequireComponent(typeof(BaseUnit), typeof(IHealth))]
    public class CombatUnit : MonoBehaviour, ICombatUnit
    {
        private IHealth health;
        private BaseUnit baseUnit;

        public IHealth Health => health;

        public IUnit BaseUnit => baseUnit;

        public void Awake()
        {
            health = GetComponent<IHealth>();
            baseUnit = GetComponent<BaseUnit>();

            
            // TESTING PURPOSES ONLY
            this.Health.SetMaxHealth(100);
            this.Health.SetCurrentHealth(this.Health.MaxHealth);
        }

    }
}
