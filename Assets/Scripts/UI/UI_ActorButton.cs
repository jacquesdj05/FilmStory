using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ActorButton : MonoBehaviour
{
    // Preset location ID designated to this button
    public int thisActorID;

    public Actor thisActor;
    public Film currentFilm;

    private void Start()
    {
        // Find that actor ID in the actor manager
        thisActor = CastLoader.Instance.actorList[thisActorID];
        currentFilm = FilmManager.Instance.preProductionFilm.GetComponent<Film>();
    }


    // save actor to film when clicked
    public void AddSelectedActorToFilm()
    {
        if (currentFilm.filmActors.Count < currentFilm.numberOfCast)
        {
            currentFilm.filmActors.Add(thisActor.actorID);
            Debug.Log("Actor added: " + thisActor.actorID);
        }
        else
        {
            Debug.Log("Actor limit reached for this film");
        }
    }
}
