using System.Collections.Generic;
using DungeonDivers.Core.Interfaces.Card;
using UnityEngine;

namespace DungeonDivers.Card
{
    public class CardDeckContext : MonoBehaviour, ICardDeck
    {
        [SerializeField] private List<BaseCard> deck;
        public IReadOnlyList<ICard> Deck => deck;

        public void AddCards(ICard obj)
        {
            if (obj is not BaseCard card) return;
            deck.Add(card);
        }

        public void RemoveCards(ICard obj)
        {
            if (obj is not BaseCard card) return;
            deck.Remove(card);
        }
    }
}
