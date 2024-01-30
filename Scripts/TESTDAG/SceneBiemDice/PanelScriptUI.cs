using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelScriptUI : MonoBehaviour
{
    public TextMeshProUGUI numbertext;

    // Start is called before the first frame update
    void Start()
    {
        numbertext.text = "" + 0;
    }

    private void ChangeNumbers(int _numbers)
    {
        numbertext.text = "" + _numbers;
    }

    private void ResetNumbers()
    {
        numbertext.text = "" + 0;
    }

    private void OnEnable()
    {
        BuittonClick.AdjustNumberEvent += ChangeNumbers;
        BuittonClickSmall.ResetEvent += ResetNumbers;
    }
    private void OnDisable()
    {
        BuittonClick.AdjustNumberEvent -= ChangeNumbers;
        BuittonClickSmall.ResetEvent -= ResetNumbers;
    }
}