using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonDivers.Arena
{
    public class ArenaStateManager : MonoBehaviour
    {
        public enum EArenaStates
        {
            START,
            PLAYER_TURN,
            PLAYER_AFTER_TURN,
            ENEMY_TURN,
            ENEMY_AFTER_TURN,
        }

        // Emits on current state changes  
        public UnityEvent<EArenaStates> OnCurrentArenaStateChange;


        // Sets Current Arena State
        private EArenaStates currentArenaState;

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
                    nextState = EArenaStates.PLAYER_TURN;
                    break;
                case EArenaStates.PLAYER_TURN:
                    nextState = EArenaStates.PLAYER_AFTER_TURN;
                    break;
                case EArenaStates.PLAYER_AFTER_TURN:
                    nextState = EArenaStates.ENEMY_TURN;
                    break;
                case EArenaStates.ENEMY_TURN:
                    nextState = EArenaStates.ENEMY_AFTER_TURN;
                    break;
                case EArenaStates.ENEMY_AFTER_TURN:
                    nextState = EArenaStates.PLAYER_TURN;
                    break;
            }
            ChangeCurrentState(nextState);
        }

    }


#if UNITY_EDITOR
    [CustomEditor(typeof(ArenaStateManager))]
    public class ArenaStateManagerInspector : Editor
    {
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            ArenaStateManager stateManager = target as ArenaStateManager;
            if (GUILayout.Button("GetNextState"))
            {
                stateManager.GetNextState();
            }
        }
    }
#endif
}
