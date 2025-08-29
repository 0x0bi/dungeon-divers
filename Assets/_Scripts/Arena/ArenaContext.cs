using System.Collections.Generic;
using DungeonDivers.Core.Interfaces.Unit;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonDivers.Arena
{
    public enum EArenaState
    {
        UNINTIALIZED,
        START,
        PLAYER_TURN,
        PLAYER_AFTER_TURN,
        ENEMY_TURN,
        ENEMY_AFTER_TURN,
        VICTORY,
        DEFEAT

    }
    public class ArenaContext : MonoBehaviour
    {
        public EArenaState CurrentState { get; internal set; } = EArenaState.UNINTIALIZED;
        public UnityEvent OnChangeCurrentState;

        public ICombatUnit InstatiatedPlayer { get; internal set; }
        public List<ICombatUnit> InstantiatedEnemies { get; internal set; }
        internal readonly BattleController battleController = new();
    }
}
