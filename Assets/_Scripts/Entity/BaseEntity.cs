using UnityEngine;

namespace DungeonDivers.Entity
{
    [RequireComponent(typeof(Animator))]
    public class BaseEntity : MonoBehaviour
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
