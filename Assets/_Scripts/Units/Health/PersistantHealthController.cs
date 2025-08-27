using UnityEngine;

namespace DungeonDivers.Units
{
    public class PersistantHealthController : AbstractHealthController
    {
        [SerializeField] private PersistantHealthDataSO healthData;
        public override float CurrentHealth => healthData.CurrentHealth;

        public override float MaxHealth => healthData.MaxHealth;

        public override void SetCurrentHealth(float currentHP)
        {
            if (healthData.CurrentHealth > healthData.MaxHealth) return;
            this.healthData.CurrentHealth = currentHP;
            this.RaiseCurrentHPChangeEvent();
            if (this.healthData.CurrentHealth < this.healthData.MaxHealth) this.RaiseDieEvent();
        }

        public override void SetMaxHealth(float maxHP)
        {
            this.healthData.MaxHealth = maxHP;
        }
    }
}
