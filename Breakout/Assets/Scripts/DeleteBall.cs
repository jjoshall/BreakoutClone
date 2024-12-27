using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeleteBall : MonoBehaviour
{
     public GameObject ball;
     public LivesManager livesManager;
     public TextMeshProUGUI spawnBallText;
     public Transform ballSpawn;

     // If ball hits the bottom wall, deactivate the ball
     void OnTriggerEnter2D(Collider2D other)
     {
          if (other.CompareTag("Ball"))
          {
               livesManager.RemoveLife();

               // Set spawnBallText to active
               spawnBallText.gameObject.SetActive(true);

               other.gameObject.SetActive(false);
          }
     }

     private void Update()
     {
          if (livesManager.livesStack.Count > 0)
          {
               // If the ball is inactive and the user presses the space key, spawn a new ball
               if (Input.GetKeyDown(KeyCode.Space) && !ball.activeInHierarchy)
               {
                    ball.transform.position = ballSpawn.position;
                    ball.SetActive(true);

                    // Get the ball's rigidbody component and make it move down
                    Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
                    rb.velocity = Vector2.down * 5;

                    spawnBallText.gameObject.SetActive(false);
               }
          }
          else
          {
               // If there are no lives left, show the Game Over screen
               SceneManager.LoadScene("GameOver");
          }
     }
}
