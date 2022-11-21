using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGame : MonoBehaviour
{
    public Player Player;
    public Finish Finish;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player) | other.TryGetComponent(out GoodCube _))
        {
            Player.Score += Finish.Points;
            Player.Won();
        }
    }
}
