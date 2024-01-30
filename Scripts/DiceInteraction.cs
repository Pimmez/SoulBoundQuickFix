using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceInteraction : MonoBehaviour
{
    public PlayerScores pScores;

    public List<GameObject> diceObjects = new List<GameObject>();
    public List<DiceCheckerInteraction> diceChecks = new List<DiceCheckerInteraction>();

    public List<Color> colors = new List<Color>();
    public List<Material> factionMaterials;

    private bool isDiceRerolled = false;
    private int count;

    public void ResetDices()
    {
        for (int i = 0; i < diceObjects.Count; i++)
        {
            diceObjects[i].GetComponent<Renderer>().material.SetColor("_Color", Color.white);
          
            for (int j = 0; j < diceChecks.Count; j++)
            {
                diceChecks[j].isDiceChecked = false;
            }
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < diceObjects.Count; i++)
        {
            diceObjects[i].GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }
    }

    private void ChangeDiceColor()
    {
        if (count == 1)
        {
            isDiceRerolled = true;
        }

        for (int i = 0; i < diceChecks.Count; i++)
        {       
            if (diceChecks[i].isDiceChecked == false)
            {
                diceObjects[i].GetComponent<Renderer>().material.SetColor("_Color", colors[UnityEngine.Random.Range(i, colors.Count)]);                
            }           
        }
        
        count++;

        if (isDiceRerolled)
            StartCoroutine(CheckPoints());
    }

    private IEnumerator CheckPoints()
    {
        foreach (GameObject obj in diceObjects)
        {
            if (obj.GetComponent<Renderer>().material.color == factionMaterials[0].color)
            {
                //add point++;
                if(pScores.PurePoints <= pScores.MaxSoulPoints)
                {
                    pScores.PurePoints += 2;
                    //pScores.factionTexts[0].text = "" + pScores.PurePoints;
                }
                
            }
            else if (obj.GetComponent<Renderer>().material.color == factionMaterials[1].color)
            {
                //point++;
                if (pScores.CursedPoints <= pScores.MaxSoulPoints)
                {
                    pScores.CursedPoints += 2;
                }
            }
            else if (obj.GetComponent<Renderer>().material.color == factionMaterials[2].color)
            {
                //point++;
                if (pScores.InfernalPoints <= pScores.MaxSoulPoints)
                {
                    pScores.InfernalPoints += 2;
                }
            }
            else if (obj.GetComponent<Renderer>().material.color == factionMaterials[3].color)
            {
                //point++;
                if (pScores.DivinePoints <= pScores.MaxSoulPoints)
                {
                    pScores.DivinePoints += 2;
                }
            }
            else if (obj.GetComponent<Renderer>().material.color == factionMaterials[4].color)
            {
                //point++;
                if (pScores.BeastPoints <= pScores.MaxSoulPoints)
                {
                    pScores.BeastPoints += 2;
                }
            }
            else if (obj.GetComponent<Renderer>().material.color == factionMaterials[5].color)
            {
                //point++;
                if (pScores.TaintedPoints <= pScores.MaxSoulPoints)
                {
                    pScores.TaintedPoints += 2;
                }
            }
        }

        isDiceRerolled = false;
        count = 0;

        yield break;
    }

    private void ActivationLeverAction()
    {
        //Lever is at fullest length
        //Change Dice Rotation
        ChangeDiceColor();
    }

    public void OnEnable()
    {
        LeverEventScript.LeverEvent += ActivationLeverAction;
    }

    public void OnDisable()
    {
        LeverEventScript.LeverEvent -= ActivationLeverAction;
    }
}