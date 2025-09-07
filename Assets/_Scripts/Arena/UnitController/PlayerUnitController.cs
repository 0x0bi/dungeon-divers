using System;
using System.Collections.Generic;
using System.Linq;
using DungeonDivers.Core.Interfaces.Card;
using DungeonDivers.Core.Interfaces.Unit;
using DungeonDivers.Core.Interfaces.Units;
using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonDivers.Arena
{
    public class PlayerUnitController : MonoBehaviour
    {
        [SerializeField] private ArenaContext context;
        [Header("Hand Settings")]
        [SerializeField] private int handCardAmount = 5;
        [SerializeField] private int totalEnergy;
        public UnityEvent<bool> IsPlayerTurnEvent;
        public UnityEvent OnPlayerHandUpdate;
        
        private ICardHolder playerCardHolder;


        private List<ICard> unusedCards;
        private List<ICard> usedCards = new();
        private Dictionary<string, ICard> currentHand = new();


        public int CurrentEnergy { get; private set; }
        public IReadOnlyDictionary<string, ICard> CurrentHand => currentHand;
        public int MaxHands => this.handCardAmount; 
        public void OnChangeCurrentState()
        {
            if (context.CurrentState == EArenaState.PLAYER_TURN)
            {
                OnPlayerTurn();
            }
            IsPlayerTurnEvent.Invoke(context.CurrentState == EArenaState.PLAYER_TURN);
        }
        public void OnPlayerUnitIntialized()
        {
            playerCardHolder = context.InstatiatedPlayer.BaseUnit.GameObject.GetComponent<ICardHolder>();
            unusedCards = playerCardHolder.Deck.ToList();
            usedCards = new();
        }

        public void NextRound()
        {
            usedCards.AddRange(currentHand.Values);
            currentHand = new();
            ArenaStateController.Instance.GetNextState();
        }

        private void OnPlayerTurn()
        {
            ResetCurrentPlayerMana();
            GetNewCurrentHand();
        }
        private void ResetCurrentPlayerMana()
        {
            CurrentEnergy = totalEnergy;
        }
        private void GetNewCurrentHand()
        {
            for (int i = 0; i < handCardAmount; i++)
            {

                if (this.unusedCards.Count == 0)
                    break;

                int randomRange;
                if (this.unusedCards.Count > 1)
                    randomRange = UnityEngine.Random.Range(0, this.unusedCards.Count);
                else
                    randomRange = 0;

                string id = Guid.NewGuid().ToString();
                this.currentHand.Add(id, this.unusedCards[randomRange]);
                this.unusedCards.RemoveAt(randomRange);
            }
            this.OnPlayerHandUpdate.Invoke();
        }


    }
}
