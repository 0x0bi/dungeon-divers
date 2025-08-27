using System;
using UnityEngine;

namespace DungeonDivers.Units
{
    [CreateAssetMenu(fileName = "NewEntityData", menuName = "Units/UnitData")]
    public class UnitDataSO : ScriptableObject
    {
        [Header("Visualization")]
        public BaseUnit prefab;
        public Sprite icon;

        [Header("Stats")]
        public BaseStats baseStats;
    }

    [Serializable]
    public class BaseStats
    {
        [SerializeField]
        private float Health;
    }
}
