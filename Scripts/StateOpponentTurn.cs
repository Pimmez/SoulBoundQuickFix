using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateOpponentTurn : State
{
    public StateOpponentTurn(GameManager gameManager) : base(gameManager)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log("Start Opponents TURN");
        GameManager.textTurnPlayer.text = "Player #2";
        yield return new WaitForSeconds(1);
        //yield break;
        GameManager.StartCoroutine(Draw());
    }

    public override IEnumerator Draw()
    {
        Debug.Log("Drawcard Opponents TURN");
        GameManager.textAllround.text = "Draw Phase :: Opponent";
        yield return new WaitForSeconds(1);
        GameManager.opponentsDeck.StartCoroutine(GameManager.opponentsDeck.Draw(1));


        for (int i = 0; i < GameManager.opponentsScores.Count; i++) 
        {
            GameManager.opponentsScores[i] += Random.Range(0, 3);
        }

        GameManager.opponentScores.PurePoints += GameManager.opponentsScores[0];
        GameManager.opponentScores.CursedPoints += GameManager.opponentsScores[1];
        GameManager.opponentScores.InfernalPoints += GameManager.opponentsScores[2];
        GameManager.opponentScores.DivinePoints += GameManager.opponentsScores[3];
        GameManager.opponentScores.BeastPoints += GameManager.opponentsScores[4];
        GameManager.opponentScores.TaintedPoints += GameManager.opponentsScores[5];


        GameManager.StartCoroutine(PlaceCards());
    }

    public override IEnumerator PlaceCards()
    {
        Debug.Log("Place Cards :: Opponents");
        GameManager.textAllround.text = "PlaceCards Phase :: Opponent";


        /*
         * Place cards down or instantiate cards from hand
         * 
         * 
         */
        GameManager.OpPlaceCard();

        yield return new WaitForSeconds(1);

        GameManager.StartCoroutine(EndTurn());

    }

    public override IEnumerator EndTurn()
    {
        Debug.Log("End Turn player");
        yield return new WaitForSeconds(1);
        GameManager.SetState(new StatePlayerTurn(GameManager));
    }
}