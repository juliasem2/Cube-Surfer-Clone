using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Transform Player;
    public float Speed;
    public bool moving = true;
    private float limitMinX = -4.5f;
    private float limitMaxX = 4.5f;
    void Update()
    {
        if (moving)
        {
            Move();
            //condition for moving to the left
            if (Input.GetKey(KeyCode.A)&Player.position.x > limitMinX)
            {
                Player.position += Vector3.left * Speed * Time.deltaTime;
            }

            //condition for moving to the right
            if (Input.GetKey(KeyCode.D) & Player.position.x < limitMaxX)
            {
                Player.position += Vector3.right * Speed * Time.deltaTime;
            }
        }
    }

    //moving function
        private void Move()
    {
        Player.position += Vector3.forward * Speed * Time.deltaTime;
    }
     
}
