using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuittonClick : MonoBehaviour
{
    public static Action<int> AdjustNumberEvent;


    public Animation anim;
    private int number;

    private void Reset()
    {
        number = 0;
    }

    void OnMouseOver()
    {
        if(number <= 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.Play();
                number++;
                if (AdjustNumberEvent != null)
                {
                    AdjustNumberEvent(number);
                }
            }
        }
        else if (number >= 2)
        {
            Debug.Log("Yes its 2 times done already");
        }
    }

    private void OnEnable()
    {
        BuittonClickSmall.ResetEvent += Reset;
    }

    private void OnDisable()
    {
        BuittonClickSmall.ResetEvent -= Reset;
    }
}
