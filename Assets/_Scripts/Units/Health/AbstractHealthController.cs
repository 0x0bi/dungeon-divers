using System;
using UnityEngine;

namespace DungeonDivers.Units
{
    [RequireComponent(typeof(BaseUnit))]
    public abstract class AbstractHealthController : MonoBehaviour
    {
        public abstract float CurrentHealth { get; }
        public abstract float MaxHealth { get; }

        protected BaseUnit entity;

        public event EventHandler<BaseUnit> OnEntityDie;
        public event EventHandler<float> OnEntityCurrentHealthChange;

        protected virtual void Awake()
        {
            entity = GetComponent<BaseUnit>();
        }

        public abstract void SetMaxHealth(float maxHP);
        public abstract void SetCurrentHealth(float currentHP);

        protected void RaiseDieEvent()
        {
            this.OnEntityDie?.Invoke(this, entity);
        }
        protected void RaiseCurrentHPChangeEvent()
        {
            this.OnEntityCurrentHealthChange?.Invoke(this, CurrentHealth);
        }
    }
}
