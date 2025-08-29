using System;
using DungeonDivers.Core.Interfaces.Unit;
using UnityEngine;

namespace DungeonDivers.Units.Combat.Health
{
    public class HealthBaseContext : MonoBehaviour, IHealth
    {
        private float currentHealth;
        private float maxHealth;

        public float CurrentHealth => currentHealth;

        public float MaxHealth => maxHealth;

        public event EventHandler<float> OnCurrentHealthChange;

        public void Heal(float amount)
        {
            currentHealth = Math.Clamp(0, amount, MaxHealth);
            OnCurrentHealthChange?.Invoke(this, CurrentHealth);
        }
        public void SetCurrentHealth(float currentHP)
        {
            currentHealth = Math.Clamp(0, currentHP, MaxHealth);
            OnCurrentHealthChange?.Invoke(this, CurrentHealth);
        }
        public void SetMaxHealth(float maxHP)
        {
            maxHealth = maxHP;
        }
        public void TakeDamage(float amount)
        {
            currentHealth = Math.Clamp(0, amount, MaxHealth);
            OnCurrentHealthChange?.Invoke(this, CurrentHealth);
        }
    }
}
