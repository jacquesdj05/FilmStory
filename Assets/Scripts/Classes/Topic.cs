using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Topic
{
    public string topicName;
    public int topicID;

    // The order of the genres in the array dictates how well it is a match with this topic (0 being best)
    // [Don't repeat for Genre class - the test will be done against the topic]
    public int[] genreMatch = new int[8];

    public int[] ratingMatch = new int[3];

    // The sprite the button will use and represent the topic
    public Sprite topicIcon;

    // Add other class variables and functionality
}
