using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeScore : MonoBehaviour
{
     public TextMeshProUGUI scoreText; // Reference to the TextMeshPro text
     public BreakBrick breakBrick;

     // Retrieve the score value from the BreakBrick script
     void Update()
     {
          float currentScore = breakBrick.GetScoreValue(); // Get the player's score
          scoreText.text = currentScore.ToString();
     }
}
