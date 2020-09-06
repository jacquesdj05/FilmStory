using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Actor
{
    public int actorID;

    // load from CSV name database
    public string actorFirstName, actorLastName;

    public bool isFemale;

    public Sprite actorSprite;

    /* Other skills, traits, personalities below */
}
