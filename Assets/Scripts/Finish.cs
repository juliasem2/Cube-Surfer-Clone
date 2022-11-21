using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public int factor;
    private int points = 10;
    public Player Player;
    public int Points = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player) | collision.collider.TryGetComponent(out GoodCube _))
        {
            int _cubesCount = Player.GetComponentInParent<ChangeCubePosition>().Cubes.Count-1;
            Points += _cubesCount * points * factor;
            //Player.Score += _cubesCount * points * factor;
            Debug.Log(Player.Score);
            if (collision.collider.TryGetComponent(out Player _)&_cubesCount <= 1)
            {
                player.GetComponent<Controls>().moving = false;
                Player.Won();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player _)| other.TryGetComponent(out GoodCube _))
        {
            other.GetComponent<Controls>().moving = false;
            other.GetComponentInParent<ChangeCubePosition>().Cubes.Remove(other.gameObject);
        }        
    }
}
