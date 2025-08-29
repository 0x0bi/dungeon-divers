using DungeonDivers.Core.Interfaces.Unit;
using DungeonDivers.Core.Structs.Arena;
using UnityEngine;

namespace DungeonDivers.Card
{
    public class ApplyHeal : CardBehaviour
    {
        [SerializeField] private float HealAmount;

        internal override void OnSelect(ICombatUnit caster, ICombatUnit enemies)
        {
            throw new System.NotImplementedException();
        }

        internal override void OnUse(ArenaTurnData turnData)
        {
            turnData.Enemies[turnData.TargetIndex].Health.Heal(HealAmount);
        }
    }
}
