using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;     // set the anchored position of the object BEING DRAGGED to the anchored position of the item slot
            eventData.pointerDrag.GetComponent<DragDrop>().droppedInSlot = true;
        }

        // Below is for preventing the ItemSlot communicating directly with dragged item
        /*
        DragDropManager.Instance.draggedObject.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;     // set the anchored position of the object BEING DRAGGED to the anchored position of the item slot
        DragDropManager.Instance.draggedObject.GetComponent<DragDrop>().droppedInSlot = true;
        */
    }
}
