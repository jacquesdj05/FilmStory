using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_PopulateTopicsPanelV2 : MonoBehaviour
{
    public GameObject topicsPanel;

    public int numberOfButtons;
    public int numberOfLocations;

    // Start is called before the first frame update
    void Start()
    {
        numberOfButtons = TopicsLoader.Instance.topicList.Count;

        PopulateTopicButtons();


    }

    void PopulateTopicButtons()
    {
        GameObject newButton;
        GameObject newPanel;
        GameObject newText;

        Topic currentTopic;

        int locationID;

        for (int i = 0; i < numberOfButtons; i++)
        {
            // Make a child of the GameObject with this script attached (the panel in this case)
            newPanel = Instantiate(topicsPanel, transform);
            newButton = newPanel.transform.Find("Topic_Button").gameObject;

            currentTopic = TopicsLoader.Instance.topicList[i];

            // make button's label the Topic
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = currentTopic.topicName;

            // Set the topicID on the button the TopicsManager topicID [look into perhaps using a GetSet here]
            newButton.GetComponent<GetTopicName>().topicID = currentTopic.topicID;

            // Button onClick() function
            // 1. Hide the Topics panel
            // 2. Set the topic of the film - this is done on the button itself (GetTopicName class)
            Button buttonComponent = newButton.GetComponent<Button>();
            buttonComponent.onClick.AddListener(TaskOnClick);

            // Display the required location names in the text fields on the panel
            numberOfLocations = currentTopic.requiredLocation.Length;
            for (int l = 0; l < numberOfLocations; l++)
            {
                locationID = currentTopic.requiredLocation[l];

                newText = newPanel.transform.Find("Text " + l.ToString()).gameObject;


                newText.GetComponentInChildren<TextMeshProUGUI>().text = LocationsLoader.Instance.locationList[locationID].locationName;
                //newText.GetComponentInChildren<TextMeshProUGUI>().text = locationID.ToString();
            }   
        }
    }

    void TaskOnClick()
    {
        UIManager.Instance.HideUIWindow(GameObject.Find("Topics_Scroll View"));
    }
}
