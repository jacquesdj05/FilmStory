using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LocationButton : MonoBehaviour
{
    // Preset location ID designated to this button
    public int thisLocationID;

    public Location thisLocation;
    public Film currentFilm;

    private void Start()
    {
        // Find that location ID in the location manager
        thisLocation = LocationsLoader.Instance.locationList[thisLocationID];
        currentFilm = FilmManager.Instance.preProductionFilm.GetComponent<Film>();
    }


    // save location to film when clicked
    public void AddSelectedLocationToFilm()
    {
        if (currentFilm.filmLocations.Count < currentFilm.numberOfLocations)
        {
            currentFilm.filmLocations.Add(thisLocation.locationID);
            Debug.Log("Location added: " + thisLocation.locationID);
        }
        else
        {
            Debug.Log("Location limit reached for this film");
        }
    }
}
