using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckerInteraction : MonoBehaviour
{
    public bool isDiceChecked = false;
    public GameObject checker;
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDiceChecked = !isDiceChecked;
        }
    }

    private void Update()
    {
        if (isDiceChecked)
        {
            checker.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        else
        {
            checker.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }
    }
}