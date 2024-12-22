using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
     public RawImage lifePrefab;  // Prefab for the life icon
     public Transform livesParent; // Parent Transform to hold life icons (e.g., a UI panel)
     private Stack<RawImage> livesStack = new Stack<RawImage>();

     public int initialLives = 3;

     void Start()
     {
          // Initialize the stack with lives
          for (int i = 0; i < initialLives; i++)
          {
               AddLife();
          }
     }

     public void AddLife()
     {
          // Instantiate a new life icon and push it onto the stack
          RawImage newLife = Instantiate(lifePrefab, livesParent);
          livesStack.Push(newLife);
     }

     public void RemoveLife()
     {
          if (livesStack.Count > 0)
          {
               // Pop a life from the stack and destroy the RawImage
               RawImage lostLife = livesStack.Pop();
               Destroy(lostLife.gameObject);
          }
          else
          {
               GameOver();
          }
     }

     public void GameOver()
     {
          Debug.Log("Game Over!");
     }
}

