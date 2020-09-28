using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotsManager : MonoBehaviour
{
    // Singleton

    private static ShotsManager _instance;
    public static ShotsManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("ShotsManager instance is NULL");
            return _instance;
        }
    }

    [System.Serializable]
    public class shot
    {
        public string shotType;
        public int shotID;

        public int shotLocationID;

        public List<int> actorsInShot;

        public float setupTimeBase, setupTimeTotal;

        public int costBase, sexinessBase /* for the love of god, change this */, takeNumber;
    }

    // temp variable for now
    public float setupUpTimePerActor;

    public List<shot> shotOptions = new List<shot>();
    // [Maybe the shot list should be stored and tracked in the Film class]
    public List<shot> shotList = new List<shot>();

    private void Awake()
    {
        // Dont destroy this object when a new scene is loaded, unless...
        DontDestroyOnLoad(this);

        // There can be only ONE!
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(this.gameObject);

        // Populate shot class with information from active film, i.e. actors, location.
        // build out the shot types in the inspector

        // Get the current film in production
        Film currentFilm = FilmManager.Instance.preProductionFilm.GetComponent<Film>();

        foreach (shot s in shotOptions)
        {
            s.shotLocationID = currentFilm.filmLocations[1];
        }

        
    }

    public void AddShotToShotList(int chosenShotID)
    {
        // Get the current film in production
        Film currentFilm = FilmManager.Instance.preProductionFilm.GetComponent<Film>();

        foreach (shot s in shotOptions)
        {
            if (s.shotID == chosenShotID)
            {
                s.actorsInShot = currentFilm.filmActors;

                // X seconds for each actor
                s.setupTimeTotal = s.setupTimeBase + s.actorsInShot.Count * setupUpTimePerActor;

                s.takeNumber = 0;

                shotList.Add(s);
            }

        }
    }
}
