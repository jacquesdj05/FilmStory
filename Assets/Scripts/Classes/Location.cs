using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Location
{
    public string locationName;
    public int locationID;

    // Has the player (or their location scout) unlocked this location
    // if True, then show in the menu
    public bool unlocked;

    // How much it will cost to film there (usually free without permission or if boring)
    public int cost;

    // Does the player have permission to shoot there
    public bool permission = false;

    // How interesting a location is on screen
    [Range(1,3)]
    public int xFactor;

    [TextAreaAttribute(3,3)]
    public string description;

    // The order of the genres in the array dictates how well it is a match with this location (0 being best)
    // [Don't repeat for Genre class - the test will be done against the location]
    //public string[] genreMatch = new string[7];
    // Should do for topic instead (topic unlocked via location)

    // The sprite that will represent the location
    public Sprite locationIcon;
}
