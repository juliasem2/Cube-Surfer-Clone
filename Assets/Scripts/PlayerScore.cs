using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public Player Player;
    public Text Score;
    // Start is called before the first frame update
    //private void Start()
    //{
    //    Score.text = "Score: " + Player.Score.ToString();
    //}
    private void Update()
    {
        Score.text = "Score: " + Player.Score.ToString();
    }
}
