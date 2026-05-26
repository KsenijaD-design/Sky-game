using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class game_dati : MonoBehaviour
{
    public List <float> bestTimes = new List <float> ();
    private static game_dati instance;
    [SerializeField] private string leaderboardKey = "Leaderboard-1";
    
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        LoadLeaderboard();
    }
    
    private void LoadLeaderboard()
    {
        for (int i = 0; i < 5; i++)
        {
            float time = PlayerPrefs.GetFloat(leaderboardKey + i, 999.99f);
            bestTimes.Add(time);
        }
        bestTimes.Sort ();
    }

    public void AddLevelTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();
        SaveLeaderboard();
    }

    private void SaveLeaderboard()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < bestTimes.Count)
            {
                PlayerPrefs.SetFloat(leaderboardKey + i, bestTimes[i]);
            }
        }
        PlayerPrefs.Save();
    }

    public static game_dati Instance
    {
        get {return instance;}
    }
}
