using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakEffects : MonoBehaviour
{
     public float shakeDuration = 0.2f; // Duration of the shake
     public float shakeMagnitude = 0.2f; // Magnitude of the shake
     private Vector3 originalPosition; // Original camera position

     void Start()
     {
          // Store the camera's original position
          originalPosition = transform.localPosition;
     }

     public void TriggerShake()
     {
          StartCoroutine(Shake());
     }

     private IEnumerator Shake()
     {
          float elapsedTime = 0f;

          while (elapsedTime < shakeDuration)
          {
               // Generate a random offset
               float offsetX = Random.Range(-1f, 1f) * shakeMagnitude;
               float offsetY = Random.Range(-1f, 1f) * shakeMagnitude;

               // Apply the offset to the camera's position
               transform.localPosition = originalPosition + new Vector3(offsetX, offsetY, 0f);

               elapsedTime += Time.deltaTime;

               yield return null; // Wait for the next frame
          }

          // Reset the camera to its original position
          transform.localPosition = originalPosition;
     }
}
