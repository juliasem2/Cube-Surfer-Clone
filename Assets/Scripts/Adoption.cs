using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adoption : MonoBehaviour
{
    public GameObject Player;
   
    //Set parent for new cubes
    void Update()
    {
        List<GameObject> _cubes = Player.GetComponentInParent<ChangeCubePosition>().Cubes;
        foreach (GameObject t in _cubes)
        {
            if(t.transform.parent == null)
            {
                t.transform.parent = Player.transform;
            }
        }
    }
}
