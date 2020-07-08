using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Film : MonoBehaviour
{
    // NOTE: Perhaps better to read this information from "Screenplay" class
    // rather than set here explicitly
    // NOTE: Create film instance (prefab) with all elements already attached (i.e. Prod, post, etc)
    // but InActive - then activate as the the film progresses

    public string
        title, genre;

    // Drop down list to select genre -- need to remove since I can't integrate with UI dropdown
    // using string instead (above)
    //public enum FilmGenres
    //{
    //    Action,
    //    Comedy,
    //    Drama,
    //    Family,
    //    Horror,
    //    Mystery,
    //    Romance,
    //    SciFiFantasy
    //}

    //public FilmGenres genres;

    public int
        numberOfCast,
        numberOfLocations;

    // Setting scriptID as read-only (tip: can check the scriptID in the
    // inspector's "Debug Mode"
    //public int filmID { get; private set; }

    // Keep track of how many films are in the game
    // NOTE: only works with films generated in code (i.e. using the constructor),
    // not generated in the inspector
    //public static int filmCount = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        RandomCastAndLocations();
        //UIManager.onSave += SetCastAndLocation;
    }

    public void CreateNewFilm()
    {
        Debug.Log("New Film Created!");
    }

    // Randomise the number of characters and locations for the film
    // this should be dependent on genre and other perks
    public void RandomCastAndLocations()
    {
        numberOfCast = Random.Range(1, 4);
        numberOfLocations = Random.Range(1, 4);
    }

    /*
    // this will be useful when perks and other things can affect the numbers
    public void SetCastAndLocation()
    {

    }
    */
}
