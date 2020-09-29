using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_PopulateShotListPanel : MonoBehaviour
{
    public GameObject shotListedPanel;

    public int thisShotID = 0;

    public void AddShotToShotList(int chosenShotID)
    {
        GameObject newPanel;
        GameObject newText;

        string newString = "";

        // Get the current film in production
        Film currentFilm = FilmManager.Instance.preProductionFilm.GetComponent<Film>();

        foreach (ShotsManager.shot s in ShotsManager.Instance.shotOptions)
        {
            if (s.shotTypeID == chosenShotID)
            {
                s.actorsInShot = currentFilm.filmActors;

                // X seconds for each actor
                s.setupTimeTotal = s.setupTimeBase + s.actorsInShot.Count * ShotsManager.Instance.setupUpTimePerActor;

                s.takeNumber = 0;

                s.shotID = thisShotID;


                ShotsManager.Instance.shotList.Add(s);

                newPanel = Instantiate(shotListedPanel, transform);

                // Set the panel's info to the same ID as it has in the shotlist (so it can be found and deleted if needed)
                newPanel.GetComponent<ShotListDataStorage>().thisShotID = thisShotID;
                thisShotID++;

                newPanel.GetComponent<ShotListDataStorage>().thisShotTypeID = s.shotTypeID;

                // make panel's label the shot name
                newText = newPanel.transform.Find("Text 0").gameObject;
                newText.GetComponentInChildren<TextMeshProUGUI>().text = s.shotType;

                foreach (int a in s.actorsInShot)
                {
                    // list the actors in the shot
                    newText = newPanel.transform.Find("Text 1").gameObject;
                    newString = newString +
                        CastLoader.Instance.actorList[a].actorFirstName
                        + " " +
                        CastLoader.Instance.actorList[a].actorLastName
                        + "\n";
                }

                newText.GetComponentInChildren<TextMeshProUGUI>().text = newString;
                break;
            }

        }
    }
}
