using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DateTime raceStart;
    private TimeSpan raceTime;
    public delegate void TimerEvent();
    private bool Racing = false;
    
    void Start()
    {
        
    }

    private void OnEnable()
    {
        StartGate.StartRaice += StartRace;
        FinishGate.FinishRaice += EndRaice;
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
    }

    void Update()
    {
        if (Racing)
        {
            TimeSpan raceTime = DateTime.Now - raceStart;
            Debug.Log("RaceTime" + raceTime.ToString("mm\\:ss\\:ff")); 
        }
    }
}
