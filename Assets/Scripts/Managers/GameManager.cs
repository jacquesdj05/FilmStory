using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Game Manager instance is NULL");
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    // Resoures to be spent throughout the game
    public int money = 0, weeks = 0, months = 0, years = 0;

    [SerializeField]
    private int monthlyExpenses = 1000;
        //secondsPerWeek = 2;

    private void Start()
    {
        //StartCoroutine(CountWeeks());       // Used to tick time along with real-time
    }

    void Update()
    {
        CheckWeeksAndMonthsAndYears();
        UIManager.Instance.DisplayResourceValues();

        if (FilmManager.Instance.newFilm != null)
        {
            UIManager.Instance.DisplayParamValue(FilmManager.Instance.GetNewScreenplay());
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            weeks += 1;
        }
    }

    // Increment "week" every X number of seconds (allows for continuing time)
    // should be able to pause the co-routine when the game is paused or menu appears
    // ***** Used to tick time along with real-time
    //private IEnumerator CountWeeks()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(secondsPerWeek);
    //        weeks++;
    //    }
    //}

    // Increment Month every 4 weeks, increment Year every 12 months
    private void CheckWeeksAndMonthsAndYears()
    {
        if (weeks != 0 && weeks - 4 >= 0)
        {
            months++;
            weeks -= 4;
            money -= monthlyExpenses;
        }

        if (months != 0 && months - 12 >= 0)
        {
            years++;
            months -= 12;
        }
    }

    /// <summary>
    /// Adds time and money cost or gain. Negative int to subtract money, positive int to add money.
    /// Time should always be positive.
    /// </summary>
    /// <param name="moneyCost"></param>
    /// <param name="timeCost"></param>
    public void PayCost(int moneyCost, int timeCost)
    {
        weeks += timeCost;
        money += moneyCost;
    }

    /// <summary>
    /// If something only costs 'time', this function converts that time into monthly expenses
    /// that will be paid over that period. Mainly to be used to tell the player the real
    /// cost through UI
    /// </summary>
    /// <returns>int value for Monthly Cost</returns>
    public int TimeToMoneyConverter()
    {
        int monthlyMoneyCost = (FilmManager.Instance.GetNewScreenplay().timeCost / 4) * monthlyExpenses;

        return monthlyMoneyCost;
    }

    public void GoToPreProduction()
    {
        SceneManager.LoadScene("Pre-Production");
    }
}
