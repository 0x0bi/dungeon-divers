using DungeonDivers.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonDivers.Arena
{
    public class ArenaStateController : SingletonBase<ArenaStateController>
    {
        [SerializeField] private ArenaDataSO arenaData;
        // Emits on current state changes  
        public UnityEvent OnCurrentArenaStateChange;


        // Sets CurrentState and emits the change
        private void ChangeCurrentState(EArenaStates nextState)
        {
            if (this.arenaData.currentState == nextState) return;
            this.arenaData.currentState = nextState;
            OnCurrentArenaStateChange.Invoke();
        }

        // Gets The Next State and changes the currents state
        public void GetNextState()
        {
            EArenaStates nextState = EArenaStates.START;
            switch (this.arenaData.currentState)
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

        public void Start()
        {
            this.arenaData.currentState = EArenaStates.START;
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
