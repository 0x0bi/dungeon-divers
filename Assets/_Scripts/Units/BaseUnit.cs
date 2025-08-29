using DungeonDivers.Core.Interfaces.Unit;
using UnityEngine;

namespace DungeonDivers.Units
{
    [RequireComponent(typeof(Animator))]
    public class BaseUnit : MonoBehaviour, IUnit
    {
        [SerializeField] private UnitDataSO unitData;
        private Animator animator;

        public string UnitName => unitData.name;
        public string UnitDescription => unitData.description;
        public Sprite UnitIcon => unitData.icon;

        public GameObject GameObject => gameObject;

        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void PlayAnimation(string animationName)
        {
            animator.Play(animationName);
        }
    }
}
