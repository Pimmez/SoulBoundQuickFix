using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StatePlayerTurn : State
{
    public StatePlayerTurn(GameManager gameManager) : base(gameManager)
    {
    }

    public override IEnumerator Start()
    {
        if (GameManager.canPlaceCard != null)
        {
            GameManager.canPlaceCard(false);
        }
        //Debug.Log("Start PLAYER TURN");
        GameManager.textTurnPlayer.text = "Player #1";
        GameManager.textAllround.text = "Turn: Player #1!";
        yield return new WaitForSeconds(1);

        //yield break;
        GameManager.StartCoroutine(Draw());
    }

    public override IEnumerator Draw()
    {
        GameManager.textAllround.text = "Drawcard! :: Player";
        yield return new WaitForSeconds(1);
        GameManager.playerDeck.StartCoroutine(GameManager.playerDeck.Draw(1));

        if (GameManager.canPlaceCard != null)
        {
            GameManager.canPlaceCard(false);
        }

        GameManager.gamePhaseButtons[0].gameObject.SetActive(true);
    }

    public override IEnumerator Dice()
    {
        GameManager.SetUIActive(false);
        GameManager.gameCam.enabled = false;
        GameManager.diceCam.enabled = true;
        GameManager.gamePhaseButtons[0].gameObject.SetActive(false);
        
        GameManager.textAllround.text = "Roll The Dice :: Player";

        GameManager.DiceTray.SetActive(true);
        GameManager.animDiceBeam.Play("tombanimation");
        yield return new WaitForSeconds(1);
        GameManager.gamePhaseButtons[1].gameObject.SetActive(true);
    }

    public override IEnumerator ReRoll()
    {
        GameManager.gamePhaseButtons[1].gameObject.SetActive(false);
        
        GameManager.textAllround.text = "ReRoll The Dice :: Player";

        GameManager.animDiceBeam.Play("Tomb2Animation");
        yield return new WaitForSeconds(2);
        GameManager.DiceTray.SetActive(false);
        GameManager.StartCoroutine(PlaceCards());
    }

    public override IEnumerator PlaceCards()
    {
        GameManager.SetUIActive(true);

        GameManager.gameCam.enabled = true;
        GameManager.diceCam.enabled = false;

        GameManager.gamePhaseButtons[2].gameObject.SetActive(false);

        if (GameManager.canPlaceCard != null)
        {
            GameManager.canPlaceCard(true);
        }
        
        GameManager.textAllround.text = "Place cards phase :: Player";

        yield return new WaitForSeconds(1);
        GameManager.gamePhaseButtons[3].gameObject.SetActive(true);

    }

    public override IEnumerator FightFase()
    {
        GameManager.gamePhaseButtons[3].gameObject.SetActive(false);

        if (GameManager.canPlaceCard != null)
        {
            GameManager.canPlaceCard(false);
        }
        
        GameManager.textAllround.text = "Fight phase :: Player";

        yield return new WaitForSeconds(1);
        GameManager.gamePhaseButtons[4].gameObject.SetActive(true);

    }

    public override IEnumerator EndTurn()
    {
        GameManager.gamePhaseButtons[4].gameObject.SetActive(false);

        GameManager.DiceTray.SetActive(false);
        GameManager.diceInteractions.ResetDices();

        GameManager.textAllround.text = "End Turn :: Player";

        yield return new WaitForSeconds(1);
        GameManager.SetState(new StateOpponentTurn(GameManager));
    }
}