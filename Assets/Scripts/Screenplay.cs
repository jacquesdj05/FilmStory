using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Screenplay : MonoBehaviour
{
    // The cost of the screenplay to write (more perks will add more time, analagous to doing more draft)
    public int moneyCost = 0, timeCost;

    // PERKS

    // Min and max values for different parameters (between 1 and 10)
    // [Range(1f, 10f)]
    public int
        storyPoints = 10,
        plot = 0,
        character = 0,
        action = 0,
        violence = 0,
        effects = 0,
        romance = 0,
        jokes = 0,
        terror = 0,
        satire = 0,
        raunch = 0;

    public Dictionary<string, int> screenplayParams = 
        new Dictionary<string, int>();

    void Awake()
    {
        timeCost = 4;

        screenplayParams.Add("plot", 1);
        screenplayParams.Add("character", 1);
        screenplayParams.Add("action", 1);
        screenplayParams.Add("violence", 1);
        screenplayParams.Add("effects", 1);
        screenplayParams.Add("romance", 1);
        screenplayParams.Add("jokes", 1);
        screenplayParams.Add("terror", 1);
        screenplayParams.Add("satire", 1);
        screenplayParams.Add("raunch", 1);
    }
}
