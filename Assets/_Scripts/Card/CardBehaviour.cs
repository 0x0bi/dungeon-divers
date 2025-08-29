
using System;
using DungeonDivers.Core.Interfaces.Unit;
using DungeonDivers.Core.Structs.Arena;
using UnityEngine;

namespace DungeonDivers.Card
{
    [Serializable]
    public abstract class CardBehaviour
    {
        internal abstract void OnSelect(ICombatUnit caster, ICombatUnit enemies);
        internal abstract void OnUse(ArenaTurnData turnData);
    }
}