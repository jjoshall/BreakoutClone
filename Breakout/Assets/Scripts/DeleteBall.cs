using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeleteBall : MonoBehaviour
{
     public LivesManager livesManager;

     // If ball hits the bottom wall, delete the ball
     void OnTriggerEnter2D(Collider2D other)
     {
          if (other.CompareTag("Ball"))
          {
               livesManager.RemoveLife();

               Destroy(other.gameObject);
          }
     }
}
