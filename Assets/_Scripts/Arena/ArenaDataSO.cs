using System.Collections.Generic;
using DungeonDivers.Units;
using UnityEngine;

namespace DungeonDivers.Arena
{
    [CreateAssetMenu(fileName = "ArenaDataSO", menuName = "Arena/ArenaData")]
    public class ArenaDataSO : ScriptableObject
    {
        [Header("Entity Data")]
        public UnitDataSO playerData;
        public List<UnitDataSO> enemyData;

        [Header("Arena Status")]
        public EArenaStates currentState = EArenaStates.START;

        // Instantiated Player and Enemies
        public InstantiatedUnitStruct InstantiatedPlayer { get; internal set; }
        public List<InstantiatedUnitStruct> InstantiatedEnemies { get; internal set; }
        
    }

    public struct InstantiatedUnitStruct
    {
        public BaseUnit Entity { get; private set; }
        public AbstractHealthController HealthController { get; private set; }

        public static InstantiatedUnitStruct New(BaseUnit entity, AbstractHealthController healthController)
        {
            return new()
            {
                Entity = entity,
                HealthController = healthController
            };
        }
    }

    public enum EArenaStates
    {
        START,
        SPAWN_UNITS,
        PLAYER_TURN,
        ENEMY_PROCESS,
        ENEMY_TURN,
        PLAYER_PROCESS,
        VICTORY,
        DEFEAT,
    }

}
