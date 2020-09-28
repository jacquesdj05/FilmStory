using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_PopulateCastingPanel : MonoBehaviour
{
    public GameObject actorPanel;

    public int numberOfButtons;

    // Start is called before the first frame update
    void Start()
    {
        numberOfButtons = CastLoader.Instance.actorList.Count;

        PopulateActorButtons();
    }

    void PopulateActorButtons()
    {
        GameObject newButton;
        GameObject newPanel;
        GameObject newText;

        Actor currentActor;

        for (int i = 0; i < numberOfButtons; i++)
        {
            // Make a child of the GameObject with this script attached (the panel in this case)
            newPanel = Instantiate(actorPanel, transform);
            newButton = newPanel.transform.Find("Actor_Button").gameObject;

            currentActor = CastLoader.Instance.actorList[i];

            // make panel's label the actor name
            newText = newPanel.transform.Find("Text 0").gameObject;
            string actorName = currentActor.actorFirstName + " " + currentActor.actorLastName;

            newText.GetComponentInChildren<TextMeshProUGUI>().text = actorName;

            // specify actor gender
            newText = newPanel.transform.Find("Text 1").gameObject;

            if (currentActor.isFemale)
            {
                newText.GetComponentInChildren<TextMeshProUGUI>().text = "Female";
            }
            else
            {
                newText.GetComponentInChildren<TextMeshProUGUI>().text = "Male";
            }
            
            // Set the actorID of the button the same as CastManager actorID [look into perhaps using a GetSet here]
            newButton.GetComponent<UI_ActorButton>().thisActorID = currentActor.actorID;

            // Button onClick() function
            // 1. Hide the Topics panel
            //Button buttonComponent = newButton.GetComponent<Button>();
            //buttonComponent.onClick.AddListener(TaskOnClick);
        }
    }

    //void TaskOnClick()
    //{
    //    //UIManager.Instance.HideUIWindow(GameObject.Find("Casting_Scroll View"));
    //}
}
