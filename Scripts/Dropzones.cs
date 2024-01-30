using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzones : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public PlayerScores pScores;

    public enum cardTypes {Magic, Creature, Timer};
    public cardTypes cardtypes;

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        DragAndDropCards d = eventData.pointerDrag.GetComponent<DragAndDropCards>();

        if(d != null)
        {

            if (d.gameObject.GetComponent<DisplayCard>().factionType == "Cursed")
            {
                if (d.gameObject.GetComponent<DisplayCard>().cost <= pScores.CursedPoints)
                {
                    if (d.gameObject.GetComponent<DisplayCard>().cardType == cardtypes.ToString())
                    {
                        pScores.CursedPoints -= d.gameObject.GetComponent<DisplayCard>().cost;

                        d.canBeChecked = false;
                        d.canDrag = false;

                        d.parentToReturnTo = this.transform;
                    }
                    else if (d.gameObject.GetComponent<DisplayCard>().cardType == cardTypes.Magic.ToString())
                    {
                        pScores.CursedPoints -= d.gameObject.GetComponent<DisplayCard>().cost;

                        Debug.Log("Magic Card is played");
                        Destroy(d.gameObject);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            if (d.gameObject.GetComponent<DisplayCard>().factionType == "Infernal" && pScores.InfernalPoints != 0)
            {
                

                if (d.gameObject.GetComponent<DisplayCard>().cardType == cardtypes.ToString())
                {
                    pScores.InfernalPoints -= d.gameObject.GetComponent<DisplayCard>().cost;

                    d.canBeChecked = false;
                    d.canDrag = false;

                    d.parentToReturnTo = this.transform;
                }
                else if (d.gameObject.GetComponent<DisplayCard>().cardType == cardTypes.Magic.ToString())
                {
                    pScores.InfernalPoints -= d.gameObject.GetComponent<DisplayCard>().cost;

                    Debug.Log("Magic Card is played");
                    Destroy(d.gameObject);
                }
                else
                {
                    return;
                }
            }
            if (d.gameObject.GetComponent<DisplayCard>().factionType == "Divine")
            {
                if (d.gameObject.GetComponent<DisplayCard>().cardType == cardtypes.ToString())
                {
                    pScores.DivinePoints -= d.gameObject.GetComponent<DisplayCard>().cost;

                    d.canBeChecked = false;
                    d.canDrag = false;

                    d.parentToReturnTo = this.transform;
                }
                else if (d.gameObject.GetComponent<DisplayCard>().cardType == cardTypes.Magic.ToString())
                {
                    pScores.DivinePoints -= d.gameObject.GetComponent<DisplayCard>().cost;

                    Debug.Log("Magic Card is played");
                    Destroy(d.gameObject);
                }
                else
                {
                    return;
                }
            }
            else
            {
                Debug.Log("Im returned");
                return;

            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("pointer enter");
        if (eventData.pointerDrag == null)
        {
            return;
        }
        
        DragAndDropCards d = eventData.pointerDrag.GetComponent<DragAndDropCards>();

        if (d != null)
        {
            if (d.gameObject.GetComponent<DisplayCard>().cardType == cardtypes.ToString())
            {
                d.placeholderParent = this.transform;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }

        //Debug.Log("poiter exit");
        DragAndDropCards d = eventData.pointerDrag.GetComponent<DragAndDropCards>();

        if (d != null && d.placeholderParent == this.transform)
        {
            if (d.gameObject.GetComponent<DisplayCard>().cardType == cardtypes.ToString())
            {
                d.placeholderParent = d.parentToReturnTo;
            }
        }
    }
}