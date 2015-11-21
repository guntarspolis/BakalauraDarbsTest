using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public enum CardDropZoneTypes
{
    MyHand,
    MyField,
    OpponentHand,
    OpponentField,
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

        DraggableCard d = eventData.pointerDrag.GetComponent<DraggableCard>();
        if(d != null)
        {
            d.parentToReturnTo = this.transform;
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
            d.placeholderParent = d.parentToReturnTo;
        }
    }

}
