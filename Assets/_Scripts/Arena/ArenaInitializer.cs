using System;
using System.Collections.Generic;
using DungeonDivers.Core.Interfaces.Unit;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonDivers.Arena
{
    public class ArenaInitializer : MonoBehaviour
    {
        [SerializeField] private ArenaContext context;
        [SerializeField] private ArenaInitDataSO initData;

        [Header("Spawning Area")]
        [SerializeField] private Transform PlayerSpawnPoint;
        [SerializeField] private Transform EnemySpawnPointStart;
        [SerializeField] private Transform EnemySpawnPointEnd;

        public UnityEvent OnArenaInitialized;

        public void OnChangeCurrentState()
        {
            if (context.CurrentState == EArenaState.START) InitializeArena();
        }

        private void InitializeArena()
        {
            SpawnUnits();
            OnArenaInitialized.Invoke();
            
            ArenaStateController.Instance.GetNextState();
        }

        private void SpawnUnits()
        {
            context.InstatiatedPlayer = SpawnUnit(initData.playerPrefab, PlayerSpawnPoint.position, Quaternion.identity);

            int length = initData.enemyPrefabs.Count;
            List<ICombatUnit> enemies = new();

            if (length < 2)
            {
                enemies.Add(SpawnUnit(initData.enemyPrefabs[0], EnemySpawnPointStart.position, Quaternion.identity));
                enemies.Add(SpawnUnit(initData.enemyPrefabs[1], EnemySpawnPointEnd.position, Quaternion.identity));
                return;
            }

            for (int i = 0; i < length; i++)
            {
                float fac = (float)i / (length - 1);
                Vector3 spawnPos = Vector3.Lerp(EnemySpawnPointStart.position, EnemySpawnPointEnd.position, fac);
                ICombatUnit instantiatedUnit = SpawnUnit(initData.enemyPrefabs[i], spawnPos, Quaternion.identity);
                enemies.Add(instantiatedUnit);
            }

            context.InstantiatedEnemies = enemies;
        }

        private ICombatUnit SpawnUnit(GameObject playerPrefab, Vector3 position, Quaternion identity)
        {
            GameObject gameObject = Instantiate(playerPrefab, position, identity);
            ICombatUnit combatUnit = gameObject.GetComponent<ICombatUnit>();

           

            return combatUnit;
        }
    }
}
