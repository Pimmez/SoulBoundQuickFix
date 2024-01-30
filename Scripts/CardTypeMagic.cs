using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "CardTypes/MagicCard", order = 2, fileName = "New Magic Card")]
public class CardTypeMagic : ScriptableObject
{
    public string cardName;
    public Image cardImage;
    public string cardAbility;
    public Color cardColor;
    public Image cardSubTypeIcon;
    public string cardType = "Magic";
    public CardSubTypes cardSubType;
    public CardSoulType cardSoulType;

    [SerializeField] private int defaultSoulCost;
    [SerializeField] private int defaultTimerTurns;
    public int soulCost;
    public int TimerTurns;
    
    public enum CardSoulType
    {
        Divine,
        Infernal,
        Pure,
        Tainted,
        Beast,
        Cursed
    }

    public enum CardSubTypes
    {
        Magic,
        Quick,
        Timer
    }

    public void ResetData()
    {
        soulCost = defaultSoulCost;
        TimerTurns = defaultTimerTurns;
    }
}