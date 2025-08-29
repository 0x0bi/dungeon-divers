using System.Collections.Generic;
using DungeonDivers.Core.Interfaces.Card;
using UnityEngine;

namespace DungeonDivers.Core.Interfaces.Units
{
    public interface ICardHolder
    {
        public IReadOnlyList<ICard> Deck { get; }
        public void AddCardsToDeck(ICard card);
        public void RemoveCardsFromDeck(ICard card);
    }
}
