using UnityEngine;
using DungeonDivers.Core.Interfaces.Card;
using DungeonDivers.Core.Interfaces.Unit;
using System.Collections.Generic;
using System;

namespace DungeonDivers.Core.Structs.Arena
{
    public struct ArenaTurnData
    {
        // Unit Detials
        public ICombatUnit Caster;
        public List<ICombatUnit> Enemies;
        public int TargetIndex;
        public ICard Card;

        // Current Turn Details
        public int CurrentBounce;
        public int AttackReduction;
        public bool IsAttackReductionInPercentage;
        public int HealReduction;
        public bool IsHealReductionInPercentage;

        public static ArenaTurnData New(ICombatUnit caster, List<ICombatUnit> enemies, int target, ICard card)
        {
            return new()
            {
                Caster = caster,
                Enemies = enemies,
                TargetIndex = target,
                Card = card,
                AttackReduction = 0,
                CurrentBounce = 0,
                HealReduction = 0,
                IsAttackReductionInPercentage = false,
                IsHealReductionInPercentage = false
            };
        }
    }
}
