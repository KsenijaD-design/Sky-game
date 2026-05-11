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
    [SerializeField] private TMP_Text Timertext, bestTimetext;
    private string bestTimeKey = "BestTime";
    private TimeSpan bestTime;
    
    private void OnEnable()
    {
        StartGate.StartRaice += StartRace;
        FinishGate.FinishRaice += EndRaice;
        karogs.Penalty += AddPenalty;
    }

    void AddPenalty()
    {
        penaltyTimes += new TimeSpan(0, 0, 3);
        Debug.Log("Penalty added");
    }

    private void Start()
    {
        long bestTimeInt = PlayerPrefs.GetInt(bestTimeKey, int.MaxValue);
        bestTime = new TimeSpan (bestTimeInt);
        bestTimetext.text = "Best Time " + bestTime.ToString ("mm\\:ss");
        
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
        if (raceTime < bestTime)
        {
            bestTimetext.text = "Best Time " + raceTime.ToString ("mm\\:ss"); 
            PlayerPrefs.SetInt(bestTimeKey, (int)raceTime.Ticks);
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        if (Racing)
        {
            TimeSpan raceTime = DateTime.Now - raceStart + penaltyTimes;
            Timertext.text = "Time " + raceTime.ToString("mm\\:ss");
            
        }
        
    }
}
