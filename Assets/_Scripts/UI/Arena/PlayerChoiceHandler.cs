using UnityEngine;
using DungeonDivers.Arena;

namespace DungeonDivers.UI.Arena
{
    public class PlayerChoiceHandler : MonoBehaviour
    {
        [SerializeField] private CanvasGroup group;
        [SerializeField] private PlayerBattleController battleController;

        public void OnPlayerChoiceEvent(bool active)
        {
            if (active) EnableGroup();
            else DisableGroup();
        }

        private void EnableGroup()
        {
            group.alpha = 1;
            group.interactable = true;
        }

        private void DisableGroup()
        {
            group.alpha = 0;
            group.interactable = false;
        }

        public void NextRound()
        {
            battleController.NextRound();
        }
        public void Attack()
        {
            battleController.AttackEnemy();
        }
    }
}
