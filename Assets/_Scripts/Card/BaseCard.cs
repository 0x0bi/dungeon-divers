using System.Collections.Generic;
using DungeonDivers.Core.Interfaces.Card;
using DungeonDivers.Core.Interfaces.Unit;
using DungeonDivers.Core.Structs.Arena;
using SerializeReferenceEditor;
using UnityEngine;
using UnityEngine.UI;

namespace DungeonDivers.Card
{
    [CreateAssetMenu(fileName = "BaseCardData", menuName = "Card/BaseCard")]
    public class BaseCard : ScriptableObject, ICard
    {
        [SerializeField] private string cardName;
        [SerializeField] private string cardDescription;
        [SerializeField] private Image cardImage;
        [SerializeField] private int cardManaUsage;
        [SerializeReference, SR] private List<CardBehaviour> behaviours;



        public string CardName => cardName;
        public string CardDescription => cardDescription;
        public Image CardImage => cardImage;

        public int CardManaUsage => cardManaUsage;

        public void OnSelect(ICombatUnit caster, ICombatUnit enemies)
        {
            foreach (CardBehaviour behaviour in behaviours)
            {
                behaviour.OnSelect(caster, enemies);
            }
        }

        public void OnUse(ArenaTurnData turnData)
        {
            foreach (CardBehaviour behaviour in behaviours)
            {
                behaviour.OnUse(turnData);
            }
        }
    }
}
