﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Singleton

    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("UI Manager instance is NULL");
            return _instance;
        }
    }

    // Save Button event system
    public delegate void SaveAction();
    public static event SaveAction onSaveScreenplay;

    // Cancel Button event system
    public delegate void CancelAction();
    public static event CancelAction onCancelScreenplay;

    // OK Button event system
    public delegate void NewFilmOKAction();
    public static event NewFilmOKAction onNewFilmOK;

    public string newFilmTitle { get; protected set; }
    public int newGenre { get; protected set; }
    public int newTopic { get; protected set; }

    public GameObject canvas;

    [SerializeField]
    private GameObject moneyValueUI, timeValueUI;

    [Tooltip("[0] plotValue\n[1] characterValue\n[2] actionValue\n[3] violenceValue\n[4] effectsValue\n[5] romanceValue\n[6] jokesValue\n[7] terrorValue\n[8] satireValue\n[9] raunchValue\n[10] storyPoints\n[11] characters\n[12] locations")]
    public List<TextMeshProUGUI> screenplayParams;

    [Tooltip("[0] Screenplay cost value")]
    public List<TextMeshProUGUI> costs;

    private void Awake()
    {
        // Dont destroy this object when a new scene is loaded, unless...
        DontDestroyOnLoad(this);

        // There can be only ONE!
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(this.gameObject);

        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    private void Start()
    {
        onNewFilmOK += GetNewFilmTitle;
    }

    public void ShowUIWindow(GameObject uiWindow)
    {
        uiWindow.GetComponent<UI_ShowHide>().Show();
    }

    public void HideUIWindow(GameObject uiWindow)
    {
        uiWindow.GetComponent<UI_ShowHide>().Hide();
    }

    // ********
    // THINK ABOUT USING DELEGATES / EVENTS FOR ALL OF THESE PUBLIC VARIABLES BELOW
    // (is it possible? applicable?)
    // ********

    public void DisplayResourceValues()
    {
        // Display the cash on hand in the UI and format with a comma

        // if Value field is null in the inspector, then fill it with the GameObject (also initialises)
        // TO DO: error checking. Is there a better way than checking every frame?
        if (moneyValueUI != null)
            moneyValueUI.GetComponent<TextMeshProUGUI>().text = "Money: " + GameManager.Instance.money.ToString("$#,#");
        else
            moneyValueUI = GameObject.FindGameObjectWithTag("MoneyValueUI");

        if (timeValueUI != null)
            timeValueUI.GetComponent<TextMeshProUGUI>().text =
                "W: " + GameManager.Instance.weeks.ToString()
                + " M: " + GameManager.Instance.months.ToString()
                + " Y: " + GameManager.Instance.years.ToString();
        else
            timeValueUI = GameObject.FindGameObjectWithTag("TimeValueUI");
    }

    public void DisplayParamValue(Screenplay newScreenplay)
    {
        // Display the current value of the parameter in Screenplay
        screenplayParams[0].text = newScreenplay.screenplayParams["plot"].ToString();
        screenplayParams[1].text = newScreenplay.screenplayParams["character"].ToString();
        screenplayParams[2].text = newScreenplay.screenplayParams["action"].ToString();
        screenplayParams[3].text = newScreenplay.screenplayParams["violence"].ToString();
        screenplayParams[4].text = newScreenplay.screenplayParams["effects"].ToString();
        screenplayParams[5].text = newScreenplay.screenplayParams["romance"].ToString();
        screenplayParams[6].text = newScreenplay.screenplayParams["jokes"].ToString();
        screenplayParams[7].text = newScreenplay.screenplayParams["terror"].ToString();
        screenplayParams[8].text = newScreenplay.screenplayParams["satire"].ToString();
        screenplayParams[9].text = newScreenplay.screenplayParams["raunch"].ToString();
        screenplayParams[10].text = "Story Points: " + newScreenplay.storyPoints.ToString();

        var newFilm = FilmManager.Instance.newFilm;
        screenplayParams[11].text = "Characters: " + newFilm.GetComponent<Film>().numberOfCast.ToString();
        screenplayParams[12].text = "Locations: " + newFilm.GetComponent<Film>().numberOfLocations.ToString();

        // Display the cost of creating the screenplay
        var expenses = GameManager.Instance.TimeToMoneyConverter().ToString("$#,#");
        costs[0].text = "Cost: " + newScreenplay.timeCost.ToString() + " weeks ("
            + expenses + " in expenses)";
    }

    public void AddValueButton(string paramKey)
    {
        // Add 1 to the parameter value when the button is pressed
        FilmManager.Instance.AddValue(paramKey);
    }

    public void SubtractValueButton(string paramKey)
    {
        // Subtract 1 from the parameter value when the button is pressed
        FilmManager.Instance.SubtractValue(paramKey);
    }

    public void CancelScreenplayButtonClick()
    {
        if (onCancelScreenplay != null)
            onCancelScreenplay();
        // Subscribers: FilmManager, DragDrop
    }

    public void SaveScreenplayButtonClick()
    {
        if (onSaveScreenplay != null)
            onSaveScreenplay();
        // Subscribers: FilmManager, DragDrop
    }

    public void NewFilmOKButtonClick()
    {
        if (onNewFilmOK != null)
            onNewFilmOK();
        // Subscribers: UIManager
    }

    /*
    public void CancelButton()
    {
        var newFilm = FilmManager.Instance.newFilm;
        if (newFilm != null)
        {
            Destroy(newFilm.gameObject);
            newFilm = null;

            Debug.Log("Film cancelled.");
        }
        else
        {
            Debug.Log("New Film is NULL. There is nothing to cancel!");
        }
    }
    */

    /*
    public void SaveButton()
    {
        var newFilm = FilmManager.Instance.newFilm;
        if (newFilm != null)
        {
            FilmManager.Instance.SaveScreenplay();

            Debug.Log("Film saved!");
        }
    }
    */

    /*
    public void GetFilmInfo()       // Implemented with the newFilmOK event
    {
        GetNewFilmTitle();

        FilmManager.Instance.CreateNewFilm(); // implemented with newFilmOK event in FilmManager
        
    }
    */

    public void GetNewFilmTitle()
    {
        var inputField = canvas.transform.Find("Film Title_UI Panel/FilmTitle_InputField");
        if (inputField == null)
        {
            Debug.LogError("GetNewFilmTitle() error: Input Field not found!");
        }
        else
        {
            Debug.Log("Film Title Input Field found!");
        }

        // Implement message that film title cannot be empty!
        if (inputField.GetComponent<TMP_InputField>().text != null)
        {
            newFilmTitle = inputField.GetComponent<TMP_InputField>().text;
            Debug.Log("New title is: " + newFilmTitle);

            FilmManager.Instance.CreateNewFilm();
        }
        else
        {
            Debug.Log("Film Title can't be empty!");
        }
    }

    public void GetNewFilmGenre(int selectedGenre)
    {

        newGenre = GenreManager.Instance.genreList[selectedGenre].genreID;
        string newGenreName = GenreManager.Instance.genreList[selectedGenre].genreName;
        Debug.Log("Genre selected: " + newGenreName);
    }

    public void GetNewFilmTopic(int selectedTopic)
    {
        newTopic = TopicsLoader.Instance.topicList[selectedTopic].topicID;
        string newTopicName = TopicsLoader.Instance.topicList[selectedTopic].topicName;
        Debug.Log("Topic selected: " + newTopicName);
    }

    /// <summary>
    /// Used for debugging
    /// </summary>
    public void NextSceneButton()
    {
        Debug.Log("Loading Production scene");
        GameManager.Instance.GoToProduction();
    }
}
