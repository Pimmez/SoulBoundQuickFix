using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBegin : State
{
    public StateBegin(GameManager _manager) : base(_manager)
    {
    }

    public override IEnumerator Start()
    {
        GameManager.textTurnPlayer.text = "";
        GameManager.textAllround.text = "Start Game!";
        yield return new WaitForSeconds(1);
        GameManager.textAllround.text = "Players Draw Cards";
        yield return new WaitForSeconds(1);
        GameManager.playerDeck.StartCoroutine(GameManager.playerDeck.GetStartingHand());
        yield return new WaitForSeconds(1);
        GameManager.opponentsDeck.StartCoroutine(GameManager.opponentsDeck.GetStartingHand());

        GameManager.SetState(new StatePlayerTurn(GameManager));
    }
}