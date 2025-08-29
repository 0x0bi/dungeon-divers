using DungeonDivers.Core.Interfaces.Unit;
using DungeonDivers.Core.Structs.Arena;
using UnityEngine;

namespace DungeonDivers.Card
{
    public class ApplyDamage : CardBehaviour
    {

        [SerializeField] private float DamageAmount;

        internal override void OnSelect(ICombatUnit caster, ICombatUnit enemies)
        {
            throw new System.NotImplementedException();
        }

        internal override void OnUse(ArenaTurnData turnData)
        {
            turnData.Enemies[turnData.TargetIndex].Health.TakeDamage(DamageAmount);
        }
    }
}
