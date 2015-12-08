using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public enum CardDropZoneTypes
{
    MyHand,
    MyField,
    None
}

public class CardDropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public CardDropZoneTypes dropZoneTypes = CardDropZoneTypes.None;

    public void OnDrop(PointerEventData eventData)
    {
        if(dropZoneTypes != CardDropZoneTypes.MyField)
        {
            Debug.Log("Can't drop here");
            return;
        }

        Debug.Log(eventData.pointerDrag.name + "was dropped to" + gameObject.name);
        //DraggableCard d = eventData.pointerDrag.GetComponent<DraggableCard>();
        //if(d != null)
        //{
        //    d.parentToReturnTo = this.transform;
        //}

        GameObject[] bothPlayerInstaces = GameObject.FindGameObjectsWithTag("Player");
        foreach (var singleInstance in bothPlayerInstaces)
        {
            ServerLogic sOperator = singleInstance.GetComponent<ServerLogic>();
            if (sOperator.isLocalPlayer)
            {
                sOperator.PlayCardFromHandToField(0, 0); // temp
            }
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (dropZoneTypes != CardDropZoneTypes.MyField)
        {
            return;
        }

        if (eventData.pointerDrag == null)
        {
            return;
        }
        DraggableCard d = eventData.pointerDrag.GetComponent<DraggableCard>();
        if (d != null)
        {
            d.placeholderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (dropZoneTypes != CardDropZoneTypes.MyField)
        {
            return;
        }

        if (eventData.pointerDrag == null)
        {
            return;
        }
        DraggableCard d = eventData.pointerDrag.GetComponent<DraggableCard>();
        if (d != null && d.placeholderParent == this.transform)
        {
            GameCardManager man = eventData.pointerDrag.GetComponent<GameCardManager>();
            man.putOnBoard();
            d.placeholderParent = d.parentToReturnTo;
        }
    }

}
