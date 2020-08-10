using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicsLoader : MonoBehaviour
{
    // Singleton
    private static TopicsLoader _instance;
    public static TopicsLoader Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Topics Loader instance is NULL");
            return _instance;
        }
    }

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

        /************* Start Loading Script *************/

        // Loads the entire csv as a single, long string
        TextAsset topicsData = Resources.Load<TextAsset>("TopicsData");

        // Splits the csv by new line character, making each new line an element in the 'data' array
        string[] data = topicsData.text.Split(new char[] { '\n' });

        // Don't include the first line (headings), be careful that there isn't a blank last line in the csv file
        for (int i = 1; i < data.Length; i++)
        {
            // Split each line by the comma to store each value individually as an element in 'line' array
            string[] line = data[i].Split(new char[] { ',' });

            // Save the values in the csv into a new Quest class
            Topic t = new Topic();

            // This will try to convert the value into an int, otherwise just return the string (as well as empty strings)
            int.TryParse(line[0], out t.topicID);

            t.topicName = line[1];

            // Place the Genre Match 0 (best match) into the first spot in the genre array (and so on)
            // NOTE: '99' counts as blank
            int.TryParse(line[2], out t.genreMatch[0]);
            int.TryParse(line[3], out t.genreMatch[1]);
            int.TryParse(line[4], out t.genreMatch[2]);
            int.TryParse(line[5], out t.genreMatch[3]);
            int.TryParse(line[6], out t.genreMatch[4]);
            int.TryParse(line[7], out t.genreMatch[5]);
            int.TryParse(line[8], out t.genreMatch[6]);
            int.TryParse(line[9], out t.genreMatch[7]);

            // The same for age rating match
            int.TryParse(line[10], out t.ratingMatch[0]);
            int.TryParse(line[11], out t.ratingMatch[1]);
            int.TryParse(line[12], out t.ratingMatch[2]);

            topicList.Add(t);
        }

        // Randomise the list of Topics at the start of the game
    }
}
