using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{  
    //if collision with wall,then stop moving and detete this cube from the list of active cubes
    private void OnTriggerEnter(Collider other)
    {   
        if (other.TryGetComponent(out Player player))
        {
            player.onPlayerDied();
        }
        other.GetComponent<Controls>().moving = false;
        other.GetComponentInParent<ChangeCubePosition>().Cubes.Remove(other.gameObject);
    }
}
