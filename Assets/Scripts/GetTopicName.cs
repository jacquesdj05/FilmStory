using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetTopicName : MonoBehaviour
{
    // Receives the topic of the button that was clicked and passes it to the UI Manager
    // to be used in the newFilm being created

    // Attached to the Topic Button prefab

    // May need to expand to include other details/variables of the topic (such as genre match) -
    // or maybe it can just communicate with the Topics Manager

    public void ClickedTopicName(GameObject thisButton)
    {
        string clickedTopic = thisButton.GetComponentInChildren<TextMeshProUGUI>().text;
        Debug.Log(clickedTopic + " button clicked!");
        UIManager.Instance.GetNewFilmTopic(clickedTopic);
    }
}
