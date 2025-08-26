using UnityEngine;
using DungeonDivers.Arena;

namespace DungeonDivers.UI.Arena
{
    public class PlayerChoiceHandler : MonoBehaviour
    {

        public void OnCurrentChoiceChange(ArenaStateController.EArenaStates state)
        {
            this.gameObject.SetActive(state == ArenaStateController.EArenaStates.PLAYER_TURN);
        }

        public void NextRound()
        {
            ArenaStateController.Instance.GetNextState();
        }
    }
}
