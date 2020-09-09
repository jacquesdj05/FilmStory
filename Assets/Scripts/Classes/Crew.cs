using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Crew
{
    public int crewID;

    // load from CSV name database
    public string crewFirstName, crewLastName;

    public bool isFemale;

    public bool isDirector, isCinematographer, isEditor;

    public Sprite crewSprite;

    /* Other skills, traits, personalities below */
}
