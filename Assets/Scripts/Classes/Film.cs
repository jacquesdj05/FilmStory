using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Film : MonoBehaviour
{
    // NOTE: Perhaps better to read this information from "Screenplay" class
    // rather than set here explicitly
    // NOTE: Create film instance (prefab) with all elements already attached (i.e. Prod, post, etc)
    // but InActive - then activate as the the film progresses

    public string title;

    public int genre, topic;

    // Drop down list to select genre -- need to remove since I can't integrate with UI dropdown
    // using string instead (above) - needs to be linked with Genre Buttons & class
    //public enum FilmGenres
    //{
    //    ActionAdventure,
    //    Comedy,
    //    Drama,
    //    Family - removed,
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

    // Array to store location IDs selected by the player
    public List<int> filmLocations = new List<int>();

    // Array to store actors selected by the player - probably won't be an 'int', but class instead
    public List<int> filmCastMembers = new List<int>();

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        RandomCastNumber();
        RandomLocationNumber();
        //UIManager.onSave += SetCastAndLocation;

        //for (int i = 0; i < numberOfLocations; i++)
        //{
        //    filmLocations.Add(0);
        //}

        for (int i = 0; i < numberOfCast; i++)
        {
            filmCastMembers.Add(0);
        }
    }

    public void CreateNewFilm()
    {
        Debug.Log("New Film Created!");
    }

    // Randomise the number of characters and locations for the film
    // this should be dependent on genre and other perks
    public void RandomCastNumber()
    {
        numberOfCast = Random.Range(1, 4);
    }

    public void RandomLocationNumber()
    {
        //numberOfLocations = Random.Range(1, 4);
        numberOfLocations = 4;
    }

    /*
    // this will be useful when perks and other things can affect the numbers
    public void SetCastAndLocation()
    {

    }
    */
}
