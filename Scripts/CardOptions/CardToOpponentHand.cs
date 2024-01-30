using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToOpponentHand : MonoBehaviour
{
    public GameObject opponentsHand;
    public GameObject handCard;


    // Start is called before the first frame update
    void Start()
    {
        opponentsHand = GameObject.Find("OpponentsHand");
        handCard.transform.SetParent(opponentsHand.transform, false);
        handCard.transform.localScale = Vector3.one;
        handCard.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        handCard.transform.eulerAngles = new Vector3(0, 0, 180);
    }
}