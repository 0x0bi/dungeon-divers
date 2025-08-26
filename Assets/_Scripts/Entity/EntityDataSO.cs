using System;
using UnityEngine;

namespace DungeonDivers.Entity
{
    [CreateAssetMenu(fileName = "NewEntityData", menuName = "Entity/Data")]
    public class EntityDataSO : ScriptableObject
    {
        [Header("Visualization")]
        [SerializeField] private BaseEntity prefab;
        [SerializeField] private Sprite icon;

        [Header("Stats")]
        [SerializeField]
        private BaseStats baseStats;
    }

    [Serializable]
    public class BaseStats
    {
        [SerializeField]
        private float Health;
    }
}
