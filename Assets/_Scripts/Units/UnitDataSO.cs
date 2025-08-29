using System;
using UnityEngine;

namespace DungeonDivers.Units
{
    [CreateAssetMenu(fileName = "NewEntityData", menuName = "Unit/UnitData")]
    public class UnitDataSO : ScriptableObject
    {
        internal BaseUnit prefab;
        internal Sprite icon;
        internal string description;
    } 
}
