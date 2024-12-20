using TMPro;
using UnityEngine;

public class BreakBrick : MonoBehaviour
{
     public ParticleSystem particleEffect; // Particle effect prefab
     private BreakEffects breakEffects;

     public AudioClip breakSound; // Sound for breaking bricks
     private AudioSource audioSource;
     
     public int scoreValue;        // Keeping score
     public MoveBall MoveBallScript;    // Using this to give players extra points if they hit multiple bricks before hitting the paddle
     public int bricksHit = 0;     // Keeping track of how many bricks the player has hit
     public TextMeshProUGUI comboText; // Reference to the TextMeshPro text

     void Start()
     {
          audioSource = GetComponent<AudioSource>();
          breakEffects = Camera.main.GetComponent<BreakEffects>();
     }

     private void OnCollisionEnter2D(Collision2D collision)
     {
          if (collision.gameObject.CompareTag("Brick"))
          {
               bricksHit++;
               comboText.text = bricksHit.ToString();

               PlaySound();

               // Increase the score
               if (!MoveBallScript.hitPaddle)
               {
                    scoreValue += 10 * bricksHit;
               }
               
               // Trigger camera shake
               if (breakEffects)
                    breakEffects.TriggerShake();

               // Spawn and play particle effect
               if (particleEffect)
               {
                    ParticleSystem particles = Instantiate(particleEffect, collision.transform.position, Quaternion.identity);
                    particles.Play();
                    Destroy(particles.gameObject, particles.main.duration + particles.main.startLifetime.constantMax);
               }

               // Destroy the brick
               Destroy(collision.gameObject);
          }
     }

     private void PlaySound()
     {
          // Play the brick break sound
          if (audioSource && breakSound)
               audioSource.PlayOneShot(breakSound);
     }

     public int GetScoreValue()
     {
          return scoreValue;
     }
}
