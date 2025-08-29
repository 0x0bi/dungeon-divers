using System.Collections.Generic;
using UnityEngine;

namespace DungeonDivers.Arena
{
    [CreateAssetMenu(fileName = "NewArenaInitData", menuName = "Arena/InitData")]
    public class ArenaInitDataSO : ScriptableObject
    {
        public GameObject playerPrefab;
        public List<GameObject> enemyPrefabs;
    }
}
