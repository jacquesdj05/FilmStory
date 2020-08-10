using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicsManager : MonoBehaviour
{
    // Singleton
    private static TopicsManager _instance;
    public static TopicsManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Topics Manager instance is NULL");
            return _instance;
        }
    }

    //public Topic[] topicArray;
    public List<Topic> topicList = new List<Topic>();

    void Awake()
    {
        // Dont destroy this object when a new scene is loaded, unless...
        DontDestroyOnLoad(this);

        // There can be only ONE!
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(this.gameObject);

        // Randomise the list of Topics at the start of the game

        
    }
}
