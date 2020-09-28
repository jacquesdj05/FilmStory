using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewLoader : MonoBehaviour
{
    // Singleton - derived from ActorLoader.cs

    private static CrewLoader _instance;
    public static CrewLoader Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("CrewLoader instance is NULL");
            return _instance;
        }
    }

    public List<Crew> crewList = new List<Crew>();

    private void Awake()
    {
        // There can be only ONE!
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(this.gameObject);

        /************* Load Crew Start *************/

        // Loads the entire csv as a single, long string
        TextAsset firstNames = Resources.Load<TextAsset>("FirstNames");
        TextAsset lastNames = Resources.Load<TextAsset>("LastNames");

        Debug.Log(firstNames);

        // Splits the csv by new line character, making each new line an element in the 'data' array
        string[] data = firstNames.text.Split(new char[] { '\n' });
        string[] data2 = lastNames.text.Split(new char[] { '\n' });

        // RANDOMISE data order
        Randomiser.RandomiseArray(data);
        Randomiser.RandomiseArray(data2);

        // Don't include the first line (headings), be careful that there isn't a blank last line in the csv file
        for (int i = 0; i < data.Length; i++)
        {
            // Split each line by the comma to store each value individually as an element in 'line' array
            // don't need to do for last names because there is only 1 column of data
            string[] line = data[i].Split(new char[] { ',' });
            //string[] line2 = data2[i].Split(new char[] { ',' });

            // Save the values in the csv into a new Crew class
            Crew a = new Crew();

            // Make the CrewID the index number (but starting from 0)
            a.crewID = i;

            // This will try to convert the value into an int, otherwise just return the string (as well as empty strings)
            bool.TryParse(line[1], out a.isFemale);

            a.crewFirstName = line[0];
            a.crewLastName = data2[i];

            // save to Crew Database
            crewList.Add(a);
        }
    }
}
