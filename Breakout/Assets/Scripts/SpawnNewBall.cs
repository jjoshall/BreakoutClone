//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class SpawnNewBall : MonoBehaviour
//{
//     public GameObject ballPrefab; // Ball prefab
//     public Transform ballSpawnPoint; // Spawn point for the ball
//     public TextMeshProUGUI spawnBallText; // Reference to the TextMeshPro text

//     void Start()
//     {
//          // Dynamically find the spawnBallText object in the scene
//          if (spawnBallText == null)
//          {
//               spawnBallText = GameObject.Find("SpawnBallText").GetComponent<TextMeshProUGUI>();
//          }

//          // Make the spawnBallText visible
//          spawnBallText.enabled = true;
//     }

//     private void Update()
//     {
//          // If there are no balls in the scene and the user presses the space key, spawn a new ball
//          if (Input.GetKeyDown(KeyCode.Space) && GameObject.FindGameObjectsWithTag("Ball").Length == 0)
//          {
//               Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
//               spawnBallText.enabled = false;
//          }
//     }
//}
