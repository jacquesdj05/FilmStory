using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotListDataStorage : MonoBehaviour
{
    // Store the shotID for the ShotListed shot so that it can be removed from the list when deleted
    public int thisShotID, thisShotTypeID;


    // Remove shot from Shot List when button is destroyed in Shot List (when panel is clicked)
    public void RemoveShotFromShotList()
    {
        foreach (ShotsManager.shot s in ShotsManager.Instance.shotList)
        {
            if (s.shotID == thisShotID)
            {
                ShotsManager.Instance.shotList.Remove(s);
                break;
            }
        }
    }
}
