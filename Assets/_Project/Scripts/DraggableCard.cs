using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DraggableCard : NetworkBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;

    GameObject placeholder = null;


    public void OnBeginDrag(PointerEventData eventData)
    {
      
        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        parentToReturnTo = this.transform.parent;
        LayoutElement lElement = placeholder.AddComponent<LayoutElement>();
        lElement.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        lElement.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        lElement.flexibleHeight = 0;
        lElement.flexibleHeight = 0;

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;
        this.transform.SetParent( this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
   
        this.transform.position = eventData.position;

        if (placeholder.transform.parent != placeholderParent)
        {
            placeholder.transform.SetParent(placeholderParent);
        }

        int newSiblingIndex = placeholderParent.childCount;
        for(int i = 0; i < placeholderParent.childCount; i++)
        {
            if(this.transform.position.x < placeholderParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;
                if(placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                {
                    newSiblingIndex--;
                }

                //placeholder.transform.SetSiblingIndex(i);
                break;
            }
        }

        placeholder.transform.SetSiblingIndex(newSiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    
        //this.transform.parent.FindChild("Field")
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(placeholder);
    }
}
