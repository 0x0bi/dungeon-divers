using UnityEngine;

namespace DungeonDivers.Units
{
    [CreateAssetMenu(fileName = "HealthData", menuName = "Units/PersistantHealthData")]
    public class PersistantHealthDataSO : ScriptableObject
    {
        public float MaxHealth { get; internal set; }
        public float CurrentHealth { get; internal set; }
    }
}
