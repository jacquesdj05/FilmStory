using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetTopicName : MonoBehaviour
{
    public void ClickedTopicName(GameObject thisButton)
    {
        string clickedTopic = thisButton.GetComponentInChildren<TextMeshProUGUI>().text;
        Debug.Log(clickedTopic + " button clicked!");
        UIManager.Instance.GetNewFilmTopic(clickedTopic);
    }
}
