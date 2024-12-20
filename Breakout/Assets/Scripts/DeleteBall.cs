using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBall : MonoBehaviour
{
     // If ball hits the bottom wall, delete the ball
     void OnTriggerEnter2D(Collider2D other)
     {
          if (other.CompareTag("Ball"))
          {
               Destroy(other.gameObject);
          }
     }
}
