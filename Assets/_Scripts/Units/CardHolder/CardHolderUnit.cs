using System.Collections.Generic;
using DungeonDivers.Core.Interfaces.Card;
using DungeonDivers.Core.Interfaces.Units;
using UnityEngine;

namespace DungeonDivers.Units.CardHolder
{
    [RequireComponent(typeof(ICardDeck))]
    public class CardHolderUnit : MonoBehaviour, ICardHolder
    {

        private ICardDeck deckData;

        public IReadOnlyList<ICard> Deck => deckData.Deck;

        public void Awake()
        {
            deckData = GetComponent<ICardDeck>();
        }
        public void AddCardsToDeck(ICard card)
        {
            deckData.AddCards(card);
        }

        public void RemoveCardsFromDeck(ICard card)
        {
            deckData.RemoveCards(card);
        }
    }
}
