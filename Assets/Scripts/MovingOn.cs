using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOn : MonoBehaviour
{
    public GameObject Player;
    
    public void MoveChildren()
    {
        List<GameObject> list = Player.GetComponent<ChangeCubePosition>().Cubes;
        for (int i = 0; i < list.Count; i++)
        {
            list[i].GetComponent<Controls>().moving = true;
        }
    }
}
