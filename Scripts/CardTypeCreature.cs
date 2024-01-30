using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "CardTypes/CreatureCard", order = 2, fileName = "New Creature Card")]
public class CardTypeCreature : ScriptableObject
{
    public string cardName;
    public Image cardImage;
    public string cardAbilityName;
    public string cardAbility;
    public string cardType = "Creature";
    public Color cardColor;
    public CardSoulType cardSoulType;

    [SerializeField] private int defaultSoulCost;
    [SerializeField] private int defaultSacrificeCost;
    [SerializeField] private int defaultAttack;
    [SerializeField] private int defaultDefense;
    public int soulCost;
    public int sacrificeCost;
    public int attack;
    public int defense;

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
        sacrificeCost = defaultSacrificeCost;
        attack = defaultAttack;
        defense = defaultDefense;
    }
}