﻿using System.Collections;
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
    public int topicID;

    //public GameObject locationsPanel;

    // Get the topic ID of the button pressed
    // Write the required locations in the placeholder text fields
    // save the topic when the Yes! is pressed

    public void ClickedTopicName(GameObject thisButton)
    {
        // Use the topicID to find the name of the topic instead
        int clickedTopic = topicID;

        Debug.Log("Topic button " + clickedTopic + " clicked!");

        UIManager.Instance.GetNewFilmTopic(clickedTopic);
    }
}
