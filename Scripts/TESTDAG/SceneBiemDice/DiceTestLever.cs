using UnityEngine;

public class DiceTestLever : MonoBehaviour
{
    public GameObject checker;
    public Material material;
    public Color[] colors;
    bool noChange = false;
    
    private void ResetColor()
    {
        material.SetColor("_Color", Color.white);
        noChange = false;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked: " + gameObject);
            noChange = !noChange;          
        }
    }

    private void ChangeDice()
    {
        if (noChange == false)
        {
            for (int i = 0; i < colors.Length; i++)
            {
                material.SetColor("_Color", colors[UnityEngine.Random.Range(0, i)]);
            }
        }
        else return;
    }

    private void Update()
    {
        if (noChange)
        {
            checker.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        else
        {
            checker.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }
    }

    public void OnEnable()
    {
        LeverEventScript.LeverEvent += ChangeDice;
        BuittonClickSmall.ResetEvent += ResetColor;
    }

    public void OnDisable()
    {
        LeverEventScript.LeverEvent -= ChangeDice;
        BuittonClickSmall.ResetEvent -= ResetColor;
    }
}