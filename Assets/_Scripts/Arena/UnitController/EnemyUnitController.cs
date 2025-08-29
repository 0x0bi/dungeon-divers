using System;
using System.Collections;
using UnityEngine;

namespace DungeonDivers.Arena
{
    public class EnemyUnitController : MonoBehaviour
    {
        [SerializeField] private ArenaContext arenaContext;
        public void OnChangeCurrentEvent()
        {
            if (arenaContext.CurrentState == EArenaState.ENEMY_TURN) StartCoroutine(NextState());
            if (arenaContext.CurrentState == EArenaState.PLAYER_AFTER_TURN) StartCoroutine(NextState());
            if (arenaContext.CurrentState == EArenaState.ENEMY_AFTER_TURN) StartCoroutine(NextState());
        }

        private IEnumerator NextState()
        {
            yield return new WaitForSeconds(1);
            ArenaStateController.Instance.GetNextState();
        }
    }
}
