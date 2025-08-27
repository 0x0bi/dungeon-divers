using DungeonDivers.Arena;
using UnityEngine;

public class HealthBarsController : MonoBehaviour
{
    [SerializeField] private ArenaDataSO arenaDataSO;
    [SerializeField] private HealthBar healthBarPrefab;

    [Header("Parent Imports")]
    [SerializeField] private Transform playerParent;
    [SerializeField] private Transform enemyParent;

    public void HandleUnitsInitialized()
    {
        InitializePlayerHealthBar();
        InitializeEnemyHealthBar();
    }

    void InitializePlayerHealthBar()
    {
        HealthBar hbar = Instantiate(healthBarPrefab, playerParent);
        hbar.SetHealthController(arenaDataSO.InstantiatedPlayer.HealthController);
    }

    void InitializeEnemyHealthBar()
    {
        foreach (InstantiatedUnitStruct enemy in arenaDataSO.InstantiatedEnemies)
        {
            HealthBar hbar = Instantiate(healthBarPrefab, enemyParent);
            hbar.SetHealthController(enemy.HealthController);
        }
    }
}
