using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Level Level;
    //public int PointCounts=0;

    public void onPlayerDied()
    {
        Level.EndGame();
    }

    public void Won()
    {
        Level.Finishing();
    }

    public int Score
    {
        get => PlayerPrefs.GetInt("Score", 0);
        set
        {
            PlayerPrefs.SetInt("Score", value);
            PlayerPrefs.Save();
        }
    }
}
