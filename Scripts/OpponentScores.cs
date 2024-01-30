using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpponentScores : MonoBehaviour
{
    public List<TextMeshProUGUI> factionTexts = new List<TextMeshProUGUI>();

    public int PurePoints { get { return purePoints; } set { purePoints = value; } }
    public int CursedPoints { get { return cursedPoints; } set { cursedPoints = value; } }
    public int InfernalPoints { get { return infernalPoints; } set { infernalPoints = value; } }
    public int DivinePoints { get { return divinePoints; } set { divinePoints = value; } }
    public int BeastPoints { get { return beastPoints; } set { beastPoints = value; } }
    public int TaintedPoints { get { return taintedPoints; } set { taintedPoints = value; } }

    public int MaxSoulPoints { get { return maxSoulPoints; } }

    private int purePoints = 0;
    private int cursedPoints = 0;
    private int infernalPoints = 0;
    private int divinePoints = 0;
    private int beastPoints = 0;
    private int taintedPoints = 0;

    private int maxSoulPoints = 12;

    private void Awake()
    {
        for (int i = 0; i < factionTexts.Count; i++)
        {
            factionTexts[i].text = "0";
        }
    }

    private void Update()
    {
        factionTexts[0].text = "" + purePoints;
        factionTexts[1].text = "" + cursedPoints;
        factionTexts[2].text = "" + infernalPoints;
        factionTexts[3].text = "" + divinePoints;
        factionTexts[4].text = "" + beastPoints;
        factionTexts[5].text = "" + taintedPoints;
    }
}