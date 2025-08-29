using UnityEngine;

namespace DungeonDivers.Units.Combat.Health
{
    [CreateAssetMenu(fileName = "NewHealthData", menuName = "Unit/PersistantHealth")]
    public class PersistantHealthDataSO : ScriptableObject
    {
        internal float CurrentHealth;
        internal float MaxHealth;
    }
}
