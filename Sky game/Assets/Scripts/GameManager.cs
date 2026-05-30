using System;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private DateTime raceStart;
    private TimeSpan raceTime;
    private TimeSpan penaltyTimes;
    public delegate void TimerEvent();
    private bool Racing = false;
    [SerializeField] private TMP_Text Timertext;
    private string bestTimeKey = "BestTime";
    private TimeSpan bestTime;
    
    private void Awake()
    {
        StartGate.StartRaice += StartRace;
        FinishGate.FinishRaice += EndRaice;
        karogs.Penalty += AddPenalty;
    }
    private void OnDisable()
    {
        StartGate.StartRaice -= StartRace;
        FinishGate.FinishRaice -= EndRaice;
        karogs.Penalty -= AddPenalty;
    }

    void AddPenalty()
    {
        penaltyTimes += new TimeSpan(0, 0, 3);
        Debug.Log("Penalty added");
    }

    private void Start()
    {
        
    }
    void StartRace()
    {
        Racing = true;
        raceStart = DateTime.Now;
        Debug.Log("StartRace");
    }

    void EndRaice()
    {
        Racing = false;
        if (game_dati.Instance != null)
        {
            game_dati.Instance.AddLevelTime((float)raceTime.TotalMilliseconds / 1000f);
        }
        else
        {
            Debug.LogError("game_dati.Instance == null в EndRaice! (singleton ещё не проснулся)");
        }

        // обновляем лучший результат
        if (raceTime < bestTime)
        {
            
            PlayerPrefs.SetInt(bestTimeKey, (int)raceTime.Ticks);
            PlayerPrefs.Save();
        } 
    }

    void Update()
    {
        if (Racing)
        {
            raceTime = DateTime.Now - raceStart + penaltyTimes;
            Timertext.text = "Time " + raceTime.ToString("mm\\:ss");
        }
        
    }
}
