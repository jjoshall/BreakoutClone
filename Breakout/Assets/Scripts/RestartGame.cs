using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
     // If user presses R, restart the game
     void Update()
     {
          if (Input.GetKeyDown(KeyCode.R))
          {
               // Reload the currently active scene
               SceneManager.LoadScene(SceneManager.GetActiveScene().name);
          }
     }
}
