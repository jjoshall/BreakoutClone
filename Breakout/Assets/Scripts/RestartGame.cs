using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
     private void Update()
     {
          if (Input.GetKeyDown(KeyCode.R))
          {
               Restart();
          }
     }

     public void Restart()
     {
          SceneManager.LoadScene("SampleScene");
          Time.timeScale = 1f;
     }
}
