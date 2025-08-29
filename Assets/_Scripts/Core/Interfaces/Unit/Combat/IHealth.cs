using System;
using UnityEngine;

namespace DungeonDivers.Core.Interfaces.Unit
{
    public interface IHealth
    {
        public float CurrentHealth { get; }
        public float MaxHealth { get; }
        public event EventHandler<float> OnCurrentHealthChange;
        public void Heal(float amount);
        public void TakeDamage(float amount);
        public void SetMaxHealth(float maxHP);
        public void SetCurrentHealth(float currentHP);
    }
}
