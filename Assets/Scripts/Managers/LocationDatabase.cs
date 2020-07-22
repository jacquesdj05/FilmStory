using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationDatabase : MonoBehaviour
{
    // Singleton

    private static LocationDatabase _instance;
    public static LocationDatabase Instance
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

    public List<Location> locationDB = new List<Location>();
}
