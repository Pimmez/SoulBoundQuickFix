using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    public List<BaseCard> displayCards = new List<BaseCard>();
    public int displayID;

    public int id;
    public string cardName;
    public int cost;
    public int sacrifice;
    public int attack;
    public int defense;
    public string cardDescription;
    public string cardType;
    public string factionType;
    public Sprite cardHolder;
    public Sprite cardImage;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI sacrificeText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI cardTypeText;
    public TextMeshProUGUI cardDescriptionText;

    public bool isCardBack;
    public static bool staticCardBack;

    public GameObject hand;
    public int numberOfCardsInDeck;
    public string handname;

    public Image cardCorrectImage;
    public Image cardHolderImage;

    // Start is called before the first frame update
    void Start()
    {
        numberOfCardsInDeck = PlayerDeck.deckSize;
        
        displayCards[0] = CardDatabase.deckDivinelist[displayID];

    }

    // Update is called once per frame
    void Update()
    {
        id = displayCards[0].id;
        cardName = displayCards[0].cardName;
        cost = displayCards[0].cost;
        sacrifice = displayCards[0].sacrifice;
        attack = displayCards[0].attack;
        defense = displayCards[0].defense;
        cardType = displayCards[0].cardType;
        cardDescription = displayCards[0].cardDescription;
        cardHolder = displayCards[0].cardHolder;
        cardImage = displayCards[0].cardImage;
        factionType = displayCards[0].factionType;

        nameText.text = "" + cardName;
        costText.text = "" + cost;
        sacrificeText.text = "" + sacrifice;
        attackText.text = "" + attack;
        defenseText.text = "" + defense;
        cardDescriptionText.text = "" + cardDescription;
        cardTypeText.text = "" + cardType;
        cardHolderImage.sprite = cardHolder;
        cardCorrectImage.sprite = cardImage;

        hand = GameObject.Find(handname);

        if(this.transform.parent.name == "Hand")
        {
            isCardBack = false;
        }
        else if(this.transform.parent.name == "OpponentsHand")
        {
            isCardBack= true;
        }
        else
        {
            isCardBack = false;
        }

        staticCardBack = isCardBack;
    
        if(this.tag == "Clone")
        {
            displayCards[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            isCardBack = false;
            this.tag = "Untagged";
        }
        else if(this.tag == "OpponentClone")
        {
            displayCards[0] = OpponentsDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            OpponentsDeck.deckSize -= 1;
            isCardBack = false;
            this.tag = "Untagged";
        }
    }
}