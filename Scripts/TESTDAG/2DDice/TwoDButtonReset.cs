using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoDButton : MonoBehaviour
{
    public static Action RandomizeDiceEvent;
    public Button button;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if(RandomizeDiceEvent != null)
            RandomizeDiceEvent();
    }
}