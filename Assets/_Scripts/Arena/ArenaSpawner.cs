using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonDivers.Arena
{
    public class ArenaSpawner : MonoBehaviour
    {
        [Header("Prefabs and Spawn Prefs")]
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameObject enemyPrefab;


        [Header("Spawn Points")]
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private List<Transform> enemySpawnPoints;


        [Header("Events")]
        [SerializeField] private UnityEvent<GameObject, GameObject[]> OnEntitySpawned;
        public void OnChangeCurrentArenaState(ArenaStateController.EArenaStates currentState)
        {
            if (currentState != ArenaStateController.EArenaStates.SPAWN_UNITS) return;
            HandleArenaSpawning();
        }

        private void HandleArenaSpawning()
        {
            GameObject playerInstance = SpawnPlayers();
            GameObject[] enemyInstances = SpawnEnemies();
            OnEntitySpawned.Invoke(playerInstance, enemyInstances);
            MoveToNextArenaState();
        }

        private void MoveToNextArenaState()
        {
            ArenaStateController.Instance.GetNextState();
        }

        private GameObject[] SpawnEnemies()
        {
            List<GameObject> gameObject = new();
            foreach (Transform spawnPoint in enemySpawnPoints)
            {
                gameObject.Add(Instantiate(enemyPrefab, spawnPoint));

            }
            return gameObject.ToArray();
        }

        private GameObject SpawnPlayers()
        {
            return Instantiate(playerPrefab, playerSpawnPoint);
        }

    }
}
