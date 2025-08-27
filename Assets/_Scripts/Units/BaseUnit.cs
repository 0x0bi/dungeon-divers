using UnityEngine;

namespace DungeonDivers.Units
{
    [RequireComponent(typeof(Animator))]
    public class BaseUnit : MonoBehaviour
    {
        private Animator animator;
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
