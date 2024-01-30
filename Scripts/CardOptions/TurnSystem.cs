using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{

    public bool isYourTurn;
    public int yourTurn;
    public int isOpponnentTurn;
    public TextMeshProUGUI turnText;

    public int maxMana;
    public int currentMana;
    public TextMeshProUGUI manaText;

    public static bool startTurn;

    public GameObject diceRoll;

    // Start is called before the first frame update
    void Start()
    {
        diceRoll.SetActive(false);
        isYourTurn = true;
        yourTurn = 1;
        isOpponnentTurn = 0;

        maxMana = 12;
        currentMana = 1;

        startTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isYourTurn)
        {
            turnText.text = "Players Turn";
        }
        else
        {
            turnText.text = "Opponents Turn";
        }
        manaText.text = currentMana + "/" + maxMana;
    }

    private void DiceRollAction()
    {
        diceRoll.SetActive(true);

    }

    public void EndYourTurn()
    {
        isYourTurn = false;
        isOpponnentTurn += 1;
    }

    public void EndOpponentsTurn()
    {
        isYourTurn = true;
        yourTurn += 1;
        
        if(currentMana < maxMana)
        {
            currentMana += 1;
        }
        else
        {
            return;
        }
        startTurn = true;
    }
}