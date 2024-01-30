using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropCards : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;
    private GameObject placeholder = null;

    public bool canBeChecked = true;
    public bool canDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            placeholder = new GameObject();
            placeholder.transform.SetParent(this.transform.parent);
            LayoutElement _layoutElement = placeholder.AddComponent<LayoutElement>();
            _layoutElement.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
            _layoutElement.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
            _layoutElement.flexibleHeight = 0;
            _layoutElement.flexibleWidth = 0;

            placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

            parentToReturnTo = this.transform.parent;
            placeholderParent = parentToReturnTo;
            this.transform.SetParent(this.transform.parent.parent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }   
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(canDrag)
        {
            this.transform.position = eventData.position;
            //Debug.Log("Drag");

            if (placeholder.transform.parent != placeholderParent)
            {
                placeholder.transform.SetParent(placeholderParent);
            }

            int newSublingIndex = placeholderParent.childCount;

            for (int i = 0; i < placeholderParent.childCount; i++)
            {
                if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
                {
                    newSublingIndex = i;

                    if (placeholder.transform.GetSiblingIndex() < newSublingIndex)
                    {
                        newSublingIndex--;
                    }

                    break;
                }
            }

            placeholder.transform.SetSiblingIndex(newSublingIndex);
        }   
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            Destroy(placeholder);
        }
        else
        {
            this.transform.SetParent(parentToReturnTo);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(canBeChecked)
        {
            this.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
    
    private void CanCardsBePlaced(bool _value)
    {
       // Debug.Log("bool: " + _value);
        canDrag = _value;
    }


    public void OnEnable()
    {
        GameManager.canPlaceCard += CanCardsBePlaced;
    }

    public void OnDisable()
    {
        GameManager.canPlaceCard -= CanCardsBePlaced;
    }
}