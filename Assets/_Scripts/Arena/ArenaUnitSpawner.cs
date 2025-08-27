using System;
using System.Collections.Generic;
using DungeonDivers.Entity;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonDivers.Arena
{
    public class ArenaUnitSpawner : MonoBehaviour
    {
        [SerializeField] private ArenaDataSO arenaData;

        [Header("Player Spawn Point")]
        [SerializeField] private Transform PlayerSpawnPoint;

        [Header("Enemy Spawn Point")]
        [SerializeField] private Transform EnemySpawnPointStart;
        [SerializeField] private Transform EnemySpawnPointEnd;

        public UnityEvent OnUnitsInitialized;

        public void OnChangeCurrentEvent()
        {
            if (arenaData.currentState != EArenaStates.SPAWN_UNITS) return;
            SpawnUnits();
        }

        private void SpawnUnits()
        {
            SpawnPlayer();
            Debug.Log("Spawned Players");
            SpawnEnemy();
            Debug.Log("Spawned Enemies");
            OnUnitsInitialized.Invoke();
            ArenaStateController.Instance.GetNextState();
        }

        // Spawns Player
        // TO DO : NEED to add collision such that it can handle card interaction
        private void SpawnPlayer()
        {
            this.arenaData.InstantiatedPlayer = SpwanUnit(PlayerSpawnPoint.position, arenaData.playerData.prefab, Quaternion.identity);
        }

        // Spawns Enemy
        // TO DO : NEED to add collision such that it can handle card interaction
        private void SpawnEnemy()
        {
            int length = arenaData.enemyData.Count;
            List<InstantiatedUnitStruct> enemies = new();
            if (length < 2)
            {
                SpwanUnit(EnemySpawnPointStart.position, arenaData.enemyData[0].prefab, Quaternion.identity);
                SpwanUnit(EnemySpawnPointEnd.position, arenaData.enemyData[1].prefab, Quaternion.identity);
                return;
            }

            for (int i = 0; i < length; i++)
            {
                float fac = (float)i / (length - 1);
                Vector3 spawnPos = Vector3.Lerp(EnemySpawnPointStart.position, EnemySpawnPointEnd.position, fac);
                InstantiatedUnitStruct instantiatedUnit = SpwanUnit(spawnPos, arenaData.enemyData[i].prefab, Quaternion.identity);
                enemies.Add(instantiatedUnit);
            }
            this.arenaData.InstantiatedEnemies = enemies;
        }

        private InstantiatedUnitStruct SpwanUnit(Vector3 spawnPos, BaseEntity prefab, Quaternion rotation)
        {
            BaseEntity baseEntity = Instantiate(prefab, spawnPos, rotation);
            AbstractHealthController healthController = baseEntity.GetComponent<AbstractHealthController>();
            healthController.SetCurrentHealth(100);
            healthController.SetMaxHealth(100);

            return InstantiatedUnitStruct.New(baseEntity, healthController);
        }
    }
}
