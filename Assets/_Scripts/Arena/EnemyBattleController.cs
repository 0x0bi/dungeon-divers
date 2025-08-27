using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonDivers.Arena
{
    public class EnemyBattleController : MonoBehaviour
    {
        [SerializeField] private ArenaDataSO arenaData;

        public void OnChangeCurrentEvent()
        {
            if (arenaData.currentState == EArenaStates.ENEMY_TURN)
            {
                foreach (InstantiatedUnitStruct enemy in arenaData.InstantiatedEnemies)
                {
                    arenaData.InstantiatedPlayer.HealthController.SetCurrentHealth(arenaData.InstantiatedPlayer.HealthController.CurrentHealth - 10);
                }
                ArenaStateController.Instance.GetNextState();
            }
            if (arenaData.currentState == EArenaStates.ENEMY_PROCESS)
            {
                StartCoroutine(NextState());
            }

        }

        private IEnumerator NextState()
        {
            yield return new WaitForSeconds(1);
            ArenaStateController.Instance.GetNextState();
        }
    }
}
