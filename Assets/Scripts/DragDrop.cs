using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // Implement various interfaces from UnityEngine.EventSystems

    [SerializeField]
    private Canvas canvas;  // necessary to ensure the object moves with the mouse regardless of screen aspect ratio

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;    // necessary to access "blocks raycast"

    private Vector3 startPosition;

    public bool droppedInSlot = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        startPosition = GetComponent<RectTransform>().anchoredPosition;
        UIManager.onSaveScreenplay += ResetPerk;
        UIManager.onCancelScreenplay += ResetPerk;
    }

    //private void OnDisable()
    //{
    //    UIManager.onSave -= ResetPerk;
    //}

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;     // Allows ray cast to go through object and hit the "Item Slot"
        canvasGroup.alpha = 0.6f;

        //DragDropManager.Instance.draggedObject = this.gameObject;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        Debug.Log("Dropped in slot? " + droppedInSlot);

        if (droppedInSlot == false)
        {
            rectTransform.anchoredPosition = startPosition;
        }

        //DragDropManager.Instance.draggedObject = null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;  // Add the amount the mouse moved since the last frame (eventData.delta)

        if (droppedInSlot == true)
        {
            droppedInSlot = false;
        }
    }

    public void ResetPerk()
    {
        rectTransform.anchoredPosition = startPosition;
    }
}
