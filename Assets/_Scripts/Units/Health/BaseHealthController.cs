using UnityEngine;

namespace DungeonDivers.Units
{
    public class BaseHealthController : AbstractHealthController
    {

        private float currentHealth;
        private float maxHealth;
        public override float CurrentHealth => currentHealth;

        public override float MaxHealth => maxHealth;

        public override void SetCurrentHealth(float currentHP)
        {
            if (currentHealth > maxHealth) return;
            this.currentHealth = currentHP;
            this.RaiseCurrentHPChangeEvent();
            if (currentHealth < maxHealth) this.RaiseDieEvent();
        }

        public override void SetMaxHealth(float maxHP)
        {
            this.maxHealth = maxHP;
        }
    }
}
