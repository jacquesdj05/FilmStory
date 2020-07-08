using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropManager : MonoBehaviour
{
    // Singleton **** not used at the moment

    private static DragDropManager _instance;
    public static DragDropManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Drag Drop Manager instance is NULL");
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    // Create a way to capture the item being dragged (perk) and have ItemSlot communicate with
    // it here, rather than with the item directly.

    /*
    public GameObject draggedObject = null;

    private void Update()
    {
        Debug.Log("Dragged object: " + draggedObject);
    }
    */
}
