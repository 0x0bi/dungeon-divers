using System;
using System.Collections.Generic;
using DungeonDivers.Core.Interfaces.Unit;
using DungeonDivers.Core.Structs.Arena;
using UnityEngine;

namespace DungeonDivers.Core.Interfaces.Card
{
    
    public interface ICard
    {
        public string CardName { get; }
        public string CardDescription { get; }
        public UnityEngine.UI.Image CardImage { get; }
        public int CardManaUsage { get; }

        public void OnSelect(ICombatUnit caster, ICombatUnit enemies);
        public void OnUse(ArenaTurnData turn);
    }

}

