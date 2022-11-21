using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumberText : MonoBehaviour
{
    public Text Text;
    public Level Level;
    // Start is called before the first frame update
    private void Start()
    {
        Text.text = "Level "+(Level.LevelIndex+1).ToString();
        
    }

}
