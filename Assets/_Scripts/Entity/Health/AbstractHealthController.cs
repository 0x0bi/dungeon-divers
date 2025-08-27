using System;
using UnityEngine;

namespace DungeonDivers.Entity
{
    [RequireComponent(typeof(BaseEntity))]
    public abstract class AbstractHealthController : MonoBehaviour
    {
        public abstract float CurrentHealth { get; }
        public abstract float MaxHealth { get; }

        protected BaseEntity entity;

        public event EventHandler<BaseEntity> OnEntityDie;
        public event EventHandler<float> OnEntityCurrentHealthChange;

        protected virtual void Awake()
        {
            entity = GetComponent<BaseEntity>();
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
