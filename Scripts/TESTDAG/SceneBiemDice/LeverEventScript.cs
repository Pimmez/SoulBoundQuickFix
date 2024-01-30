using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverEventScript : MonoBehaviour
{
    public static Action LeverEvent;

    public void DiceRoll()
    {
        if(LeverEvent != null) 
        {
            LeverEvent();
        }
    }
}