using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : StateMachine
{
    public static Action<bool> canPlaceCard;

    public Camera gameCam;
    public Camera diceCam;

    public List<GameObject> setUI = new List<GameObject>();



    public PlayerDeck playerDeck;
    public OpponentsDeck opponentsDeck;

    public List<int> opponentsScores = new List<int>();
    public OpponentScores opponentScores;

    public DiceInteraction diceInteractions;
    public Animation animDiceBeam;
    public GameObject DiceTray;
    public TextMeshProUGUI textAllround;

    public TextMeshProUGUI textTurnPlayer;

    public List<Button> gamePhaseButtons = new List<Button>();

    public bool noInitialeCards = true;

    public GameObject parentObjectenemie;
    public GameObject prefab;

    private void Awake()
    {
        gameCam = Camera.main;
        gameCam.enabled = true;
        diceCam.enabled = false;
    }

    private void Start()
    {
        diceInteractions.ResetDices();
        
        DiceTray.SetActive(false);
        SetState(new StateBegin(this));
        //Debug.Log("GAMENAGER HALLO?");
    }

    public void SetUIActive(bool _isActive)
    {
        for (int i = 0; i < setUI.Count; i++)
        {
            setUI[i].SetActive(_isActive);
        }
    }

    public void OnRollDiceButton()
    {
        StartCoroutine(State.Dice());
    }

    public void OnRerollDiceButton()
    {
        StartCoroutine(State.ReRoll());
    }

    public void PlaceCardsState()
    {
        StartCoroutine(State.PlaceCards());
    }

    public void FightCardsState()
    {
        StartCoroutine(State.FightFase());
    }

    public void OnEndTurn()
    {
        StartCoroutine(State.EndTurn());
    }

    public void OpPlaceCard()
    {
        Instantiate(prefab, parentObjectenemie.transform.parent);

        prefab.transform.SetParent(parentObjectenemie.transform, false);
        prefab.SetActive(true);
        Debug.Log(prefab);
    }

}