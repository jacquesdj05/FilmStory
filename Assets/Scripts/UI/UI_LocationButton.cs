using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LocationButton : MonoBehaviour
{
    // Preset location ID designated to this button
    public int thisLocationID;

    public Location thisLocation;

    private void Start()
    {
        // Find that location ID in the location manager
        thisLocation = LocationsLoader.Instance.locationList[thisLocationID];
    }


    // save location to film when clicked
    public void AddSelectedLocationToFilm()
    {
        FilmManager.Instance.preProductionFilm.GetComponent<Film>().filmLocations.Add(thisLocation.locationID);
    }
}
