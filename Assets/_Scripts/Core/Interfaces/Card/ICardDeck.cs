using System.Collections.Generic;
using UnityEngine;

namespace DungeonDivers.Core.Interfaces.Card
{
    public interface ICardDeck
    {
        public IReadOnlyList<ICard> Deck { get; }
        void RemoveCards(ICard card);
        void AddCards(ICard card);
    }
}
