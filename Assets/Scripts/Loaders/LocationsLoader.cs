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
                Debug.LogError("Locations Loader instance is NULL");
            return _instance;
        }
    }

    public List<Location> locationList = new List<Location>();

    private void Awake()
    {
        // There can be only ONE!
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(this.gameObject);

        /************* Load Locations Start *************/

        // Loads the entire csv as a single, long string
        TextAsset locationsData = Resources.Load<TextAsset>("LocationsData_proto");

        // Splits the csv by new line character, making each new line an element in the 'data' array
        string[] data = locationsData.text.Split(new char[] { '\n' });

        // Don't include the first line (headings), be careful that there isn't a blank last line in the csv file
        for (int i = 1; i < data.Length; i++)
        {
            // Split each line by the comma to store each value individually as an element in 'line' array
            string[] line = data[i].Split(new char[] { ',' });

            // Save the values in the csv into a new Location class
            Location l = new Location();

            // This will try to convert the value into an int, otherwise just return the string (as well as empty strings)
            int.TryParse(line[0], out l.locationID);

            l.locationName = line[1];

            bool.TryParse(line[2], out l.unlocked);

            int.TryParse(line[3], out l.cost);

            int.TryParse(line[4], out l.xFactor);

            l.description = line[5];

            locationList.Add(l);
        }
    }
}