using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenreManager : MonoBehaviour
{
    // Singleton
    private static GenreManager _instance;
    public static GenreManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Topics Manager instance is NULL");
            return _instance;
        }
    }

    //public Genre[] topicArray;
    public List<Genre> genreList = new List<Genre>();

    void Awake()
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
