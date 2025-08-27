using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonDivers.Arena
{
    public class PlayerBattleController : MonoBehaviour
    {
        [SerializeField] private ArenaDataSO arenaData;
        public UnityEvent<bool> OnPlayerChoiceEvent;


        public void OnCurrentChoiceChange()
        {
            OnPlayerChoiceEvent.Invoke(arenaData.currentState == EArenaStates.PLAYER_TURN);
            if (arenaData.currentState == EArenaStates.PLAYER_PROCESS)
            {
                StartCoroutine(NextState());
            }
        }

        public void AttackEnemy()
        {
            foreach (InstantiatedUnitStruct units in arenaData.InstantiatedEnemies)
            {
                units.HealthController.SetCurrentHealth(units.HealthController.CurrentHealth - 10);
            }
        }

        private IEnumerator NextState()
        {
            yield return new WaitForSeconds(1);
            ArenaStateController.Instance.GetNextState();
        }

        public void NextRound()
        {
            ArenaStateController.Instance.GetNextState();
        }
    }
}
