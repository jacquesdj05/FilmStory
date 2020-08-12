using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationsLoader : MonoBehaviour
{
    // Singleton

    private static LocationsLoader _instance;
    public static LocationsLoader Instance
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
        // There can be only ONE!
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(this.gameObject);
    }
}
