using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuittonClickSmall : MonoBehaviour
{
    public static Action ResetEvent;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)){
            if(ResetEvent != null)
            {
                ResetEvent();
            }
        }
    }
}
