using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TwoDiceTest : MonoBehaviour, IPointerClickHandler
{
    public Image checkImage = null;
    public Image image;
    public Color[] colors;
    bool noChange = false;

    public void OnPointerClick(PointerEventData eventData)
    {

        Debug.Log("Clicked: " + gameObject);
        noChange = !noChange;

    }

    private void ResetColor()
    {
        image.color = Color.white;
        noChange = false;
    }

    private void ChangeDice()
    {
        if (noChange == false)
        {
            for (int i = 0; i < colors.Length; i++)
            {
                image.color = colors[UnityEngine.Random.Range(0, i)];
            }
        }
        else return;
    }

    private void Update()
    {
        if (noChange)
        {
            checkImage.color = Color.green;
        }
        else if (!noChange)
        {
            checkImage.color = Color.white;
        }
    }

    public void OnEnable()
    {
        TwoDButton.RandomizeDiceEvent += ChangeDice;
        TwoDButtonReset.ResetDiceEvent += ResetColor;
    }

    public void OnDisable()
    {
        TwoDButton.RandomizeDiceEvent -= ChangeDice;
        TwoDButtonReset.ResetDiceEvent -= ResetColor;
    }
}