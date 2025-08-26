using DungeonDivers.Utils;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonDivers.Arena
{
    public class ArenaStateController : SingletonBase<ArenaStateController>
    {
        public enum EArenaStates
        {
            START,
            SPAWN_UNITS,
            PLAYER_TURN,
            ENEMY_PROCESS,
            ENEMY_TURN,
            PLAYER_PROCESS,
        }

        // Emits on current state changes  
        public UnityEvent<EArenaStates> OnCurrentArenaStateChange;

        // Sets Current Arena State
        [SerializeField] private EArenaStates currentArenaState;

        // Getter for current Arena State;
        public EArenaStates CurrentArenaState => currentArenaState;


        // Sets CurrentState and emits the change
        private void ChangeCurrentState(EArenaStates nextState)
        {
            if (currentArenaState == nextState) return;
            currentArenaState = nextState;
            OnCurrentArenaStateChange.Invoke(currentArenaState);
        }

        // Gets The Next State and changes the currents state
        public void GetNextState()
        {
            EArenaStates nextState = EArenaStates.START;
            switch (currentArenaState)
            {
                case EArenaStates.START:
                    nextState = EArenaStates.SPAWN_UNITS;
                    break;
                case EArenaStates.SPAWN_UNITS:
                    nextState = EArenaStates.PLAYER_TURN;
                    break;
                case EArenaStates.PLAYER_TURN:
                    nextState = EArenaStates.ENEMY_PROCESS;
                    break;
                case EArenaStates.ENEMY_PROCESS:
                    nextState = EArenaStates.ENEMY_TURN;
                    break;
                case EArenaStates.ENEMY_TURN:
                    nextState = EArenaStates.PLAYER_PROCESS;
                    break;
                case EArenaStates.PLAYER_PROCESS:
                    nextState = EArenaStates.PLAYER_TURN;
                    break;
            }
            ChangeCurrentState(nextState);
        }

        // On Start Sets Current State To Start        
        public void Start()
        {
            ChangeCurrentState(EArenaStates.SPAWN_UNITS);    
        }

    }


#if UNITY_EDITOR
    [CustomEditor(typeof(ArenaStateController))]
    public class ArenaStateControllerEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            ArenaStateController stateManager = target as ArenaStateController;
            if (GUILayout.Button("GetNextState"))
            {
                stateManager.GetNextState();
            }
        }
    }
#endif
}
