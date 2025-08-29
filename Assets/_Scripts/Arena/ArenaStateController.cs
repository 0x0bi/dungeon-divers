using System;
using System.Collections;
using Codice.Client.BaseCommands.Import;
using DungeonDivers.Utils;
using JetBrains.Annotations;
using UnityEngine;

namespace DungeonDivers.Arena
{
    public class ArenaStateController : SingletonBase<ArenaStateController>
    {
        [SerializeField] private ArenaContext context;
        private bool isEventProcessing;
        public void Start()
        {
            ChangeCurrentState(EArenaState.START);
        }
        public void GetNextState()
        {
            EArenaState nextState = context.CurrentState;
            switch (context.CurrentState)
            {
                case EArenaState.START:
                    nextState = EArenaState.PLAYER_TURN;
                    break;
                case EArenaState.PLAYER_TURN:
                    nextState = EArenaState.PLAYER_AFTER_TURN;
                    break;
                case EArenaState.PLAYER_AFTER_TURN:
                    nextState = EArenaState.ENEMY_TURN;
                    break;
                case EArenaState.ENEMY_TURN:
                    nextState = EArenaState.ENEMY_AFTER_TURN;
                    break;
                case EArenaState.ENEMY_AFTER_TURN:
                    nextState = EArenaState.PLAYER_TURN;
                    break;
            }

            ChangeCurrentState(nextState);
        }
        private void ChangeCurrentState(EArenaState nextState)
        {
            StartCoroutine(ChangeNextState(nextState));
        }

        private IEnumerator ChangeNextState(EArenaState nextState)
        {
            yield return new WaitUntil(() => !isEventProcessing);
            isEventProcessing = true;
            if (context.CurrentState == nextState) yield return null;
            context.CurrentState = nextState;
            context.OnChangeCurrentState.Invoke();
            isEventProcessing = false;
        }
    }
}