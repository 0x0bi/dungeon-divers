using System;
using UnityEngine;

namespace DungeonDivers.Entity
{
    [CreateAssetMenu(fileName = "NewEntityData", menuName = "Units/UnitData")]
    public class EntityDataSO : ScriptableObject
    {
        [Header("Visualization")]
        public BaseEntity prefab;
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
