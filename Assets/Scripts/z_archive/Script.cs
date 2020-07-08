using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Script
{
    /* The scripts that the player is able to create are defined
    by these vairables. Tweaking the sliders appropriately depending on
    the desired genre will be the key */

    public string
        title;

    // Drop down list to select genre
    public enum FilmGenres
    {
        Action,
        Comedy,
        Drama,
        Family,
        Horror,
        Mystery,
        Romance,
        SciFiFantasy
    }

    public FilmGenres selectedGenre;

    // Sliders to scale different parameters (between 1 and 10)
    [Range(1f, 10f)]
    public float
        plot,
        character,
        action,
        violenceAndGore,
        effects,
        romance,
        jokes,
        scares,
        satire,
        raunchiness;

    public int
        numberOfCast,
        numberOfLocations;

    // Setting scriptID as read-only (tip: can check the scriptID in the
    // inspector's "Debug Mode"
    public int scriptID { get; private set; }

    // Keep track of how many scripts are in the game
    // NOTE: only works with scripts generated in code (i.e. using the constructor),
    // not generated in the inspector
    public static int scriptCount = 0;

    // Constructor for Script classes (only required for creating class in code)
    public Script(string title, string genre,
        float plot, float character, float action, float violenceAndGore,
        float effects, float romance, float jokes, float scares,
        float satire, float raunch,
        int castNumber, int locationNumber)
    {
        this.title = title;
        
        this.plot = plot;
        this.character = character;
        this.action = action;
        this.violenceAndGore = violenceAndGore;
        this.effects = effects;
        this.romance = romance;
        this.jokes = jokes;
        this.scares = scares;
        this.satire = satire;
        this.raunchiness = raunch;

        this.numberOfCast = castNumber;
        this.numberOfLocations = locationNumber;

        switch (genre)
        {
            case "action":
                this.selectedGenre = FilmGenres.Action;
                break;
            case "comedy":
                this.selectedGenre = FilmGenres.Comedy;
                break;
            case "drama":
                this.selectedGenre = FilmGenres.Drama;
                break;
            case "family":
                this.selectedGenre = FilmGenres.Family;
                break;
            case "mystery":
                this.selectedGenre = FilmGenres.Mystery;
                break;
            case "horror":
                this.selectedGenre = FilmGenres.Horror;
                break;
            case "romance":
                this.selectedGenre = FilmGenres.Romance;
                break;
            case "scififant":
                this.selectedGenre = FilmGenres.SciFiFantasy;
                break;
            default:
                Debug.Log("ERROR: Genre input '" + genre + "' is not valid.\n" +
                    "Valid strings:\n" +
                    "action\ncomedy\ndrama\nfamily\nmystery\nhorror\nromance\nscififant");
                break;
        }

        scriptCount++;
        this.scriptID = scriptCount;
    }
}