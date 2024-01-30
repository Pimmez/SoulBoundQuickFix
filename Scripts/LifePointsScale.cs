using UnityEngine;
using UnityEngine.UI;

public class LifePointsScale : MonoBehaviour
{
    public int LifePoints { get { return lifepoints; } }
    private int lifepoints;

    public Slider lifepointsSlider;

    // Update is called once per frame
    void Update()
    {
        lifepointsSlider.value = lifepoints;

        //Test Button
        if(Input.GetKeyDown(KeyCode.U))
        {
            lifepoints += 1;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            lifepoints -= 1;
        }
    }

    private void PlusPoints(int _amount)
    {
        lifepoints += _amount;

        if (lifepoints >= 15)
        {
            //Winner
        }
    }

    private void MinPoints(int _amount)
    {
        lifepoints -= _amount;

        if (lifepoints <= -15)
        {
            //Loser
        }
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}