using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationsManager : MonoBehaviour
{
    // Singleton

    private static LocationsManager _instance;
    public static LocationsManager Instance
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
}
