using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDatabase : MonoBehaviour
{
    // TO DO: investigate the utilisation of Dictionaries to store scripts.
    // (cannot be seen in the inspector)
    public List<Script> scripts = new List<Script>();

    // Start is called before the first frame update
    void Start()
    {
        //scripts.Add(CreateScript("Hello Darkness", "Horror", 5f, 2f, 6f, 7f, 10f, 1f, 7f, 2f, 8f, 10f, 2, 1));
        scripts.Add(new Script("Goodbye Lightness", "romance", 8f, 3f, 1f, 4f, 7f, 9f, 1f, 2f, 3f, 5f, 25, 21));
        //Debug.Log("Script count: " + Script.scriptCount);
    }
    /*
    // Allows the player to create their own script
    // NOTE: isn't required to create Scripts using 'new Script()'
    private Script CreateScript(
        string title,
        string genre,
        float plot,
        float character,
        float action,
        float violenceAndGore,
        float effects,
        float romance,
        float jokes,
        float scares,
        float satire,
        float raunch,
        int castNumber,
        int locationNumber)
    {
        Script myScript = new Script(
            title,
            genre,
            plot,
            character,
            action,
            violenceAndGore,
            effects,
            romance,
            jokes,
            scares,
            satire,
            raunch,
            castNumber,
            locationNumber);

        return myScript;
    }*/
}
