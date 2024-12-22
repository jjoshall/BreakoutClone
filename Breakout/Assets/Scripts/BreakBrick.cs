using TMPro;
using UnityEngine;

public class BreakBrick : MonoBehaviour
{
     public ParticleSystem particleEffect; // Particle effect prefab
     private BreakEffects breakEffects;

     public AudioClip breakSound; // Sound for breaking bricks
     private AudioSource audioSource;
     
     public int scoreValue;        // Keeping score
     public TextMeshProUGUI scoreNum; // Reference to the TextMeshPro text
     public MoveBall MoveBallScript;    // Using this to give players extra points if they hit multiple bricks before hitting the paddle
     public int bricksHit = 0;     // Keeping track of how many bricks the player has hit
     public TextMeshProUGUI comboNum; // Reference to the TextMeshPro text

     public int scorePerBrick = 10;
     public GameObject comboPowerup;

     void Start()
     {
          audioSource = GetComponent<AudioSource>();
          breakEffects = Camera.main.GetComponent<BreakEffects>();

          // Dynamically find the comboNum object in the scene
          if (comboNum == null)
          {
               comboNum = GameObject.Find("ComboNum").GetComponent<TextMeshProUGUI>();
          }

          // Dynamically find the scoreNum object in the scene
          if (scoreNum == null)
          {
               scoreNum = GameObject.Find("ScoreNum").GetComponent<TextMeshProUGUI>();
          }
     }

     private void OnCollisionEnter2D(Collision2D collision)
     {
          if (collision.gameObject.CompareTag("Brick"))
          {
               bricksHit++;
               comboNum.text = bricksHit.ToString();

               PlaySound();

               // Increase the score
               if (!MoveBallScript.hitPaddle)
               {
                    scoreValue += scorePerBrick * bricksHit;
                    scoreNum.text = scoreValue.ToString();
               }

               // Have a 25% chance of spawning a comboPowerup
               if (Random.value < 0.15f)
               {
                    Instantiate(comboPowerup, collision.transform.position, Quaternion.identity);
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
}
