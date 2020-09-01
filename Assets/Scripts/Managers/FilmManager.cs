using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilmManager : MonoBehaviour
{
    // Singleton

    private static FilmManager _instance;
    public static FilmManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Film Manager instance is NULL");
            return _instance;
        }
    }

    private void Awake()
    {
        // Dont destroy this object when a new scene is loaded, unless...
        DontDestroyOnLoad(this);

        // There can be only ONE!
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(this.gameObject);
    }

    public GameObject film;

    // temp storage for new film until added to list after creation process complete (saved)
    public GameObject newFilm = null;

    // focus area for the film currently in pre-production. Place Game Object in here after Development
    public GameObject preProductionFilm = null;
    
    // Database of saved films
    // See if this is possible without needing GameObjects (i.e. using "film" class only)
    public List<GameObject> FilmDB = new List<GameObject>();

    private void Start()
    {
        // Subscribe Screenplay Strength algorithm
        UIManager.onSaveScreenplay += CalculateScreenplayStrength;
        UIManager.onSaveScreenplay += SaveScreenplay;
        UIManager.onCancelScreenplay += CancelScreenplay;
    }

    // Called by UI Manager in "GetNewFilmTitle()" -- could potentially do the other way around
    public void CreateNewFilm()
    {
        newFilm = Instantiate(film);
        
        var newFilmTitle = CreateNewFilmTitle(newFilm);
        var newFilmGenre = CreateNewFilmGenre(newFilm);
        var newFilmTopic = CreateNewFilmTopic(newFilm);

        newFilm.GetComponent<Transform>().name = newFilmTitle;

        Debug.Log("Created new " + newFilmGenre + " film: " + newFilmTitle);
    }

    public string CreateNewFilmTitle(GameObject newFilm)
    {
        var title = newFilm.GetComponent<Film>().title = UIManager.Instance.newFilmTitle;

        return title;
    }

    public int CreateNewFilmGenre(GameObject newFilm)
    {
        var genre = newFilm.GetComponent<Film>().genre = UIManager.Instance.newGenre;

        return genre;
    }

    public int CreateNewFilmTopic(GameObject newFilm)
    {
        var topic = newFilm.GetComponent<Film>().topic = UIManager.Instance.newTopic;

        return topic;
    }

    public Screenplay GetNewScreenplay()
    {
        // Get the new film instance
        if (newFilm != null)
        {
            var newScreenplay = newFilm.GetComponentInChildren<Screenplay>();
            // Debug.Log("Screenplay found!");

            return newScreenplay;
        }
        else
        {
            Debug.LogError("GetNewScreenplay() error: No new film");

            return null;
        }
    }

    public void AddValue(string paramKey)     // Implemented in UIManager
    {
        if (GetNewScreenplay().screenplayParams[paramKey] < 10 && GetNewScreenplay().storyPoints > 0)
        {
            GetNewScreenplay().screenplayParams[paramKey] += 1;
            GetNewScreenplay().storyPoints -= 1;
        }
    }

    public void SubtractValue(string paramKey)     // Implemented in UIManager
    {
        if (GetNewScreenplay().screenplayParams[paramKey] > 0)
        {
            GetNewScreenplay().screenplayParams[paramKey] -= 1;
            GetNewScreenplay().storyPoints += 1;
        }
    }

    public void CalculateScreenplayStrength()
    {
        var newScreenplay = newFilm.GetComponentInChildren<Screenplay>();

        // Find screenplay genre ID
        int newfilmGenreID = newFilm.GetComponent<Film>().genre;

        // Get topic class
        Topic newFilmTopic = TopicsLoader.Instance.topicList[newFilm.GetComponent<Film>().topic];

        // Get Param values
        // Get age rating (not yet implemented)

        // in topic - where does the genre fall in genreMatch array?
        // start with strength = 8, then minus 1 for each spot it is away from first.
        // if not in the array at all, minus 7 points

        // Start screenplay strength at 11 (7 for genre, 3 for age rating, 1 remainder)
        newScreenplay.screenplayStrength = 11;

        int numberToSubtract = 0;
        for (int g = 0; g < newFilmTopic.genreMatch.Length; g++)
        {
            numberToSubtract = g;

            if (newFilmTopic.genreMatch[g] == newfilmGenreID)
            {
                Debug.Log("Genre found in topic match at position " + g);
                break;
            }
        }

        newScreenplay.screenplayStrength -= numberToSubtract;

        Debug.Log("Screenplay strength is now " + newScreenplay.screenplayStrength);
    }

    public void SaveScreenplay()
    {
        // save screenplay params as unique variables -- not sure how useful this is, but can see in inspector at least
        var newScreenplay = newFilm.GetComponentInChildren<Screenplay>();
        newScreenplay.plot = newScreenplay.screenplayParams["plot"];
        newScreenplay.character = newScreenplay.screenplayParams["character"];
        newScreenplay.action = newScreenplay.screenplayParams["action"];
        newScreenplay.violence = newScreenplay.screenplayParams["violence"];
        newScreenplay.effects = newScreenplay.screenplayParams["effects"];
        newScreenplay.romance = newScreenplay.screenplayParams["romance"];
        newScreenplay.jokes = newScreenplay.screenplayParams["jokes"];
        newScreenplay.terror = newScreenplay.screenplayParams["terror"];
        newScreenplay.satire = newScreenplay.screenplayParams["satire"];
        newScreenplay.raunch = newScreenplay.screenplayParams["raunch"];

        GameManager.Instance.PayCost(newScreenplay.moneyCost, newScreenplay.timeCost);

        FilmDB.Add(newFilm);

        // Puts the last created script into Pre Production focus (assuming you want to go straight into Pre)
        preProductionFilm = FilmDB[FilmDB.Count - 1];
        newFilm = null;

        Debug.Log("Film saved!");
    }

    public void CancelScreenplay()
    {
        if (newFilm != null)
        {
            Destroy(newFilm.gameObject);
            newFilm = null;

            Debug.Log("Film cancelled.");
        }
        else
        {
            Debug.Log("New Film is NULL. There is nothing to cancel!");
        }
    }
}
