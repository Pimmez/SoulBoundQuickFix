using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<BaseCard> container = new List<BaseCard>();
    public int x;
    public static int deckSize = 60;
    public List<BaseCard> deck = new List<BaseCard>();
    public static List<BaseCard> staticDeck = new List<BaseCard>();

    public GameObject cardToHand;
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

        if(factiontypes == factionTypes.Cursed)
        {
            for (int i = 0; i < deckSize; i++)
            {
                x = Random.Range(1, CardDatabase.deckCursedlist.Count);
                deck[i] = CardDatabase.deckCursedlist[x];
            }
        }
        else if (factiontypes == factionTypes.Infernal)
        {
            for (int i = 0; i < deckSize; i++)
            {
                x = Random.Range(1, CardDatabase.deckInfernallist.Count);
                deck[i] = CardDatabase.deckInfernallist[x];
            }
        }
        else if (factiontypes == factionTypes.Divine)
        {
            for (int i = 0; i < deckSize; i++)
            {
                x = Random.Range(1, CardDatabase.deckDivinelist.Count);
                deck[i] = CardDatabase.deckDivinelist[x];
            }
        }
        else
        {
            Debug.Log("No faction selected");
        }



        //StartCoroutine(StartGame());
    }

    private void Update()
    {
        staticDeck = deck;
    }

    public IEnumerator GetStartingHand()
    {
        for (int i = 0; i <= amountOfCardsToStart; i++)
        {
            yield return new WaitForSeconds(0.2f);
            //AudioSource
            Instantiate(cardToHand, transform.position, transform.rotation);
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(0, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }
    }

    public IEnumerator Draw(int x)
    {
        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(cardToHand, transform.position, transform.rotation);
        }
    }
}