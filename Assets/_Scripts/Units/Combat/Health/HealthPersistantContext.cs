using System;
using DungeonDivers.Core.Interfaces.Unit;
using UnityEngine;

namespace DungeonDivers.Units.Combat.Health
{
    public class HealthPersistantContext : MonoBehaviour, IHealth
    {
        public PersistantHealthDataSO healthDataSO;
        public float CurrentHealth => healthDataSO.CurrentHealth;

        public float MaxHealth => healthDataSO.MaxHealth;

        public event EventHandler<float> OnCurrentHealthChange;

        public void Heal(float amount)
        {
            healthDataSO.CurrentHealth = Math.Clamp(0, amount, MaxHealth);
            OnCurrentHealthChange?.Invoke(this, CurrentHealth);
        }
        public void SetCurrentHealth(float currentHP)
        {
            healthDataSO.CurrentHealth = Math.Clamp(0, currentHP, MaxHealth);
            OnCurrentHealthChange?.Invoke(this, CurrentHealth);
        }
        public void SetMaxHealth(float maxHP)
        {
            healthDataSO.MaxHealth = maxHP;
        }
        public void TakeDamage(float amount)
        {
            healthDataSO.CurrentHealth = Math.Clamp(0, amount, MaxHealth);
            OnCurrentHealthChange?.Invoke(this, CurrentHealth);
        }
    }
}
