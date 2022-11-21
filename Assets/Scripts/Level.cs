using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Controls Controls;
    public GameObject StartWindow;
    public GameObject PlayingWindow;
    public GameObject WonWindow;
    public GameObject LossWindow;
    private GameObject CurrentScreen;

    private void Start()
    {
        CurrentScreen = StartWindow;
    }

    public enum State
    {
        Playing,
        Won,
        Loss,
    }
    public State CurrentState { get; private set; }
    
    public void EndGame()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        Controls.enabled = false;
        ChangeScreen(CurrentScreen, LossWindow);
    }

    public void Finishing()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        Controls.enabled = false;
        ChangeScreen(CurrentScreen, WonWindow);
        LevelIndex++;
    }
    public const string LevelIndexKey = "LevelIndex";
    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        ChangeScreen(CurrentScreen,PlayingWindow);
    }

    public void ChangeScreen(GameObject canvasDeActivate, GameObject canvasActivate)
    {
        canvasActivate.SetActive(true);
        canvasDeActivate.SetActive(false);
    }
}
