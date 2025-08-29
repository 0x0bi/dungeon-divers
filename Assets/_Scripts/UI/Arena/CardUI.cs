using DungeonDivers.Card;
using TMPro;
using UnityEngine;

public class CardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private BaseCard card;
    
    public void SetCard(BaseCard _card)
    {
        card = _card;
        RefreshCardUIData();
    }

    private void RefreshCardUIData()
    {
        text.text = card.CardName;
    }
}
