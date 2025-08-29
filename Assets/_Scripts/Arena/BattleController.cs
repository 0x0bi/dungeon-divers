using System.Collections.Generic;
using DungeonDivers.Core.Interfaces.Card;
using DungeonDivers.Core.Interfaces.Unit;
using DungeonDivers.Core.Structs.Arena;


namespace DungeonDivers.Arena
{
    public class BattleController
    {
        public static void UseCard(ICombatUnit caster, List<ICombatUnit> enemies, int target, ICard card)
        {
            ArenaTurnData turn = ArenaTurnData.New(caster, enemies, target, card);
            card.OnUse(turn);
        }

    }
}
