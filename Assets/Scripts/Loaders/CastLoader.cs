using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastLoader : MonoBehaviour
{
    // Singleton

    private static CastLoader _instance;
    public static CastLoader Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("CastLoader instance is NULL");
            return _instance;
        }
    }

    public List<Actor> actorList = new List<Actor>();

    private void Awake()
    {
        // There can be only ONE!
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(this.gameObject);

        /************* Load Cast Start *************/

        // Loads the entire csv as a single, long string
        TextAsset firstNames = Resources.Load<TextAsset>("FirstNames");

        // Splits the csv by new line character, making each new line an element in the 'data' array
        string[] data = firstNames.text.Split(new char[] { '\n' });

        // RANDOMISE data order
        Randomiser.RandomiseArray(data);

        // Don't include the first line (headings), be careful that there isn't a blank last line in the csv file
        for (int i = 1; i < data.Length; i++)
        {
            // Split each line by the comma to store each value individually as an element in 'line' array
            string[] line = data[i].Split(new char[] { ',' });

            // Save the values in the csv into a new Actor class
            Actor a = new Actor();

            // This will try to convert the value into an int, otherwise just return the string (as well as empty strings)
            bool.TryParse(line[0], out a.isFemale);

            a.actorFirstName = line[1];

            // save to Cast Database
            actorList.Add(a);
        }

        // ----- Repeat for Surname -----
        // Loads the entire csv as a single, long string
        TextAsset lastNames = Resources.Load<TextAsset>("LastNames");

        // Splits the csv by new line character, making each new line an element in the 'data' array
        string[] data2 = lastNames.text.Split(new char[] { '\n' });

        // RANDOMISE data2 order
        Randomiser.RandomiseArray(data2);

        // Don't include the first line (headings), be careful that there isn't a blank last line in the csv file
        for (int i = 1; i < data2.Length; i++)
        {
            // Split each line by the comma to store each value individually as an element in 'line' array
            string[] line = data2[i].Split(new char[] { ',' });

            // Save the values in the csv into an EXISTING actor class
            // in a loop, retrieve each actor in the database in turn and add the last name

            actorList[i - 1].actorLastName = line[0];
            
        }
    }
}
