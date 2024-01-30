using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OpponentsDeck;

public class OpponentsDeck : MonoBehaviour
{
    public List<BaseCard> Opponentcontainer = new List<BaseCard>();
    public int x;
    public static int deckSize = 60;
    public List<BaseCard> Opponentdeck = new List<BaseCard>();
    public static List<BaseCard> staticDeck = new List<BaseCard>();

    public GameObject cardToHand1;
    public GameObject[] Clones;
    public GameObject hand;

    public int amountOfCardsToStart = 5;

    public enum factionTypes { Cursed, Infernal, Divine };
    public factionTypes factiontypes;


    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        deckSize = 40;
        
        for (int i = 0; i < deckSize; i++)
        {
            x = Random.Range(1, CardDatabase.deckDivinelist.Count);
            Opponentdeck[i] = CardDatabase.deckDivinelist[x];
        }
        /*
        if (factiontypes == factionTypes.Cursed)
        {
            for (int i = 0; i < deckSize; i++)
            {
                x = Random.Range(1, CardDatabase.deckCursedlist.Count);
                Opponentdeck[i] = CardDatabase.deckCursedlist[x];
            }
        }
        else if (factiontypes == factionTypes.Infernal)
        {
            for (int i = 0; i < deckSize; i++)
            {
                x = Random.Range(1, CardDatabase.deckInfernallist.Count);
                Opponentdeck[i] = CardDatabase.deckInfernallist[x];
            }
        }
        else if (factiontypes == factionTypes.Divine)
        {
            for (int i = 0; i < deckSize; i++)
            {
                x = Random.Range(1, CardDatabase.deckDivinelist.Count);
                Opponentdeck[i] = CardDatabase.deckDivinelist[x];
            }
        }
        else
        {
            Debug.Log("No faction selected");
        }
        */


        //StartCoroutine(StartGame());
    }

    private void Update()
    {
        staticDeck = Opponentdeck;
    }

    public IEnumerator GetStartingHand()
    {
        for (int i = 0; i <= amountOfCardsToStart; i++)
        {
            yield return new WaitForSeconds(0.2f);
            //AudioSource
            Instantiate(cardToHand1, transform.position, Quaternion.identity);
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            Opponentcontainer[0] = Opponentdeck[i];
            int randomIndex = Random.Range(0, deckSize);
            Opponentdeck[i] = Opponentdeck[randomIndex];
            Opponentdeck[randomIndex] = Opponentcontainer[0];
        }
    }

    public IEnumerator Draw(int x)
    {
        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(cardToHand1, transform.position, Quaternion.identity);
        }
    }
}