using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCubePosition : MonoBehaviour
{
    public List<GameObject> Cubes;

    //change position.y on 1
    public void ChangePosition()
    {
        foreach (GameObject t in Cubes)
        {
            Vector3 position = t.transform.position;
            position.y += 1;
            t.transform.position = position;
        }
    }
}
