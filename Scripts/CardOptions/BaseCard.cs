using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class BaseCard
{
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
    public BaseCard()
    {

    }

    public BaseCard(int _id, string _cardName, int _cost, int _sacrifice, int _attack, int _defense, string _cardDescription, string _cardType, string _factionType, Sprite _cardHolder, Sprite _cardImage)
    {
        id = _id;
        cardName = _cardName;
        cost = _cost;   
        sacrifice = _sacrifice;
        attack = _attack;
        defense = _defense;
        cardDescription = _cardDescription;
        cardType = _cardType;
        factionType = _factionType;
        cardHolder = _cardHolder;
        cardImage = _cardImage;
    }
}