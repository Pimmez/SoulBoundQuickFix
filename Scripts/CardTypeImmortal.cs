using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "CardTypes/ImmortalCard", order = 2, fileName = "New Immortal Card")]
public class CardTypeImmortal : ScriptableObject
{
    public string cardName;
    public Image cardImage;
    public string cardAbility;
    public string leftCardAbility;
    public string rightCardAbility;
    public Color cardColor;
    public Image cardSubTypeIcon;
    public string cardType = "Immortal";
    public CardSoulType cardSoulType;

    [SerializeField] private int defaultSoulCost;
    [SerializeField] private int defaultSoulLives;
    public int soulCost;
    public int soulLives;

    public enum CardSoulType
    {
        Divine,
        Infernal,
        Pure,
        Tainted,
        Beast,
        Cursed
    }

    public void ResetData()
    {
        soulCost = defaultSoulCost;
        soulLives = defaultSoulLives;
    }
}