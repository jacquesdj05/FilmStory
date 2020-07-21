using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    // Has the player (or their location scout) unlocked this location
    // if True, then show in the menu
    public bool unlocked;

    public string locationName;

    public bool interior = false;

    // e.g. "modern", "gothic", "futristic", "rustic", etc.
    public string style;

    // How much it will cost to film there (usually free without permission or if boring)
    public int cost;

    // Does the player have permission to shoot there
    public bool permission = false;

    // How interesting a location is on screen
    [Range(1,10)]
    public int xFactor;

    public string description;
}
