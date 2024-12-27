using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScript : MonoBehaviour
{
     public BreakBrick breakBrick;
     public TextMeshProUGUI winText;

     // If there are no more bricks to break, the player wins
     void Update()
     {
          if (breakBrick.bricksToWin == 0)
          {
               Win();
          }
     }

     public void Win()
     {
          // Pause the game
          Time.timeScale = .1f;

          winText.gameObject.SetActive(true);
     }
}
