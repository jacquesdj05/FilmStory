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
    
    // Database of saved films
    public List<GameObject> FilmDB = new List<GameObject>();

    private void Start()
    {
        UIManager.onSave += SaveScreenplay;
        UIManager.onSave += CancelScreenplay;
    }

    // Called by UI Manager in "GetNewFilmTitle()" -- could potentially do the other way around
    public void CreateNewFilm()
    {
        newFilm = Instantiate(film);
        
        var newFilmTitle = CreateNewFilmTitle(newFilm);
        var newFilmGenre = CreateNewFilmGenre(newFilm);

        newFilm.GetComponent<Transform>().name = newFilmTitle;

        Debug.Log("Created new " + newFilmGenre + " film: " + newFilmTitle);
    }

    public string CreateNewFilmTitle(GameObject newFilm)
    {
        var title = newFilm.GetComponent<Film>().title = UIManager.Instance.newFilmTitle;

        return title;
    }

    public string CreateNewFilmGenre(GameObject newFilm)
    {
        var genre = newFilm.GetComponent<Film>().genre = UIManager.Instance.newGenre;

        return genre;
    }

    public void SetScreenplayParams(Screenplay newScreenplay)
    {
        // // Get the new film instance
        // if (newFilm != null)
        // {
        //     var newScreenplay = newFilm.GetComponentInChildren<Screenplay>();
        //     Debug.Log("Screenplay found!");
        //     newScreenplay.plot = 5;
        //     newScreenplay.satire = 3;
        // }
        // else
        // {
        //     Debug.LogError("No new film");
        // }
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
