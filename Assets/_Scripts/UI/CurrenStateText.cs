using UnityEngine;
using DungeonDivers.Arena;
using TMPro;

namespace DungeonDivers.UI
{
    
    public class CurrentStateText : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI text;
        public void ChangeText(ArenaStateManager.EArenaStates state)
        {
            text.text = state.ToString();
        }
    }
}
