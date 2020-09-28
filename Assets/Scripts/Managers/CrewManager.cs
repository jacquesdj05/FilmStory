using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewManager : MonoBehaviour
{
    // Singleton

    private static CrewManager _instance;
    public static CrewManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("CrewManager instance is NULL");
            return _instance;
        }
    }

    public UI_CrewSelectButton.crewEnum thisCrewType;

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

    public void SetCrewSelector(GameObject crewSelectButton)
    {
        thisCrewType = crewSelectButton.GetComponent < UI_CrewSelectButton > ().crewType;
    }
}
