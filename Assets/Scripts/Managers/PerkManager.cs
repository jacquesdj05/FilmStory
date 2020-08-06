using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkManager : MonoBehaviour
{
    // Singleton
    // Instantiates Perk prefabs in the correct production phase
    // Populates perk effects

    private static PerkManager _instance;
    public static PerkManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Perk Manager instance is NULL");
            return _instance;
        }
    }

    public List<Perk> perkList = new List<Perk>();

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
}
