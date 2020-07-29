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

    /* // Good for testing - Topics are now instead implemented with the Topic class
    public string[] topicArray = {"Alien","Biopic","Body Swap","Buddy","Car","Crime","Cyber","Dance",
        "Demonic Possession","Detective","Disfunctional Family","Distaster","Dystopian","Old Age","Culinary",
        "Forbidden Love","Ghost","Haunted House","Heist","High School","Historic War","Holiday","Journalistic",
        "Legal","Mad Scientist","Magical","Marriage","Martial Arts","Medical","Metamorphosis","Mid-Life Crisis",
        "Military","Modern War","Monster","Movie Business","Music","Musical","Nature","Noir","Occult","Period",
        "Pirate","Police","Political","Post-Apocalyptic","Prison","Prison Break","Psychological","Religious",
        "Road Trip","Robot","Royal","Science","Serial Killer","Shoot 'Em Up","Space","Space Opera","Sports",
        "Spy","Superhero","Swords & Sandals","Tech","Time Travel","Treasure","Vampire","Wall Street","Werewolf",
        "Western","Whodunnit","Youth","Zombie" }
    */

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
