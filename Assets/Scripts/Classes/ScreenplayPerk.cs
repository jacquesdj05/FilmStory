using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenplayPerk : MonoBehaviour
{
    // create a perk manager that instantiates per prefabs and assigns the values to it according to
    // the perks in its Database

    public string perkName = "perk prefab";

    // Perk Effects below that are populated by Perk Manager

    private void Awake()
    {
        GetComponent<Transform>().name = perkName;
    }
}
