using System.Collections;
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

    private void Awake()
    {
        _instance = this;
    }

    // Save Button event system
    public delegate void SaveAction();
    public static event SaveAction onSave;

    // Cancel Button event system
    public delegate void CancelAction();
    public static event CancelAction onCancel;

    [Tooltip("[0] Money value\n[1] Weeks value\n[2] Month value\n[3] Year value")]
    public List<TextMeshProUGUI> resourceValues;

    public string newFilmTitle { get; protected set; }
    public string newGenre { get; protected set; }

    [Tooltip("[0] plotValue\n[1] characterValue\n[2] actionValue\n[3] violenceValue\n[4] effectsValue\n[5] romanceValue\n[6] jokesValue\n[7] terrorValue\n[8] satireValue\n[9] raunchValue\n[10] storyPoints")]
    public List<TextMeshProUGUI> screenplayParams;

    [Tooltip("[0] Screenplay cost value")]
    public List<TextMeshProUGUI> costs;

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
        resourceValues[0].text = GameManager.Instance.money.ToString("$#,#");
        resourceValues[1].text = GameManager.Instance.weeks.ToString();
        resourceValues[2].text = GameManager.Instance.months.ToString();
        resourceValues[3].text = GameManager.Instance.years.ToString();
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
        screenplayParams[10].text = newScreenplay.storyPoints.ToString();

        // Display the cost of creating the screenplay
        var expenses = GameManager.Instance.TimeToMoneyConverter().ToString("$#,#");
        costs[0].text = newScreenplay.timeCost.ToString() + " weeks ("
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

    public void CancelButtonClick()
    {
        if (onCancel != null)
            onCancel();
        // Subscribers: FilmManager, DragDrop
    }

    public void SaveButtonClick()
    {
        if (onSave != null)
            onSave();
        // Subscribers: FilmManager, DragDrop
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

    public void GetFilmInfo()       // Implemented with the "OK button" UI button
    {
        GetNewFilmTitle();
        GetNewFilmGenre();

        FilmManager.Instance.CreateNewFilm();
        //FilmManager.Instance.SetScreenplayParams();
    }

    public void GetNewFilmTitle()
    {
        var inputField = GameObject.Find("FilmTitle_InputField");
        if (inputField == null)
        {
            Debug.LogError("GetNewFilmTitle() error: Input Field not found!");
        }

        // Implement message that film title cannot be empty!
        if (inputField.GetComponent<TMP_InputField>().text != null)
        {
            newFilmTitle = inputField.GetComponent<TMP_InputField>().text;
            Debug.Log("New title is: " + newFilmTitle);
        }
        else
        {
            Debug.Log("Film Title can't be empty!");
        }
    }

    public void GetNewFilmGenre()
    {
        var dropdown = GameObject.Find("Genre_Dropdown");
        if (dropdown == null)
        {
            Debug.LogError("GetNewFilmGenre() error: Genre Dropdown not found!");
        }

        newGenre = dropdown.GetComponent<TMP_Dropdown>().captionText.text;
        Debug.Log("Genre selected: " + newGenre);
    }

    /// <summary>
    /// Used for debugging
    /// </summary>
    public void NextSceneButton()
    {
        Debug.Log("Loading next scene");
        GameManager.Instance.GoToPreProduction();
    }
}
