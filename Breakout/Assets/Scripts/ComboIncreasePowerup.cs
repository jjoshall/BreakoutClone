//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class ComboIncreasePowerup : MonoBehaviour
//{
//     public BreakBrick breakBrick;
//     private Rigidbody2D rb;

//     public AudioClip powerSound; // Sound for breaking bricks
//     private AudioSource audioSource;

//     public ParticleSystem particleEffect; // Particle effect prefab
//     public TextMeshProUGUI comboText;

//     void Start()
//     {
//          audioSource = GetComponent<AudioSource>();

//          // Dynamically find the comboText object in the scene
//          if (comboText == null)
//          {
//               comboText = GameObject.Find("ComboText").GetComponent<TextMeshProUGUI>();
//          }

//          // Set the scorePerBrick to 10
//          breakBrick.scorePerBrick = 10;
//     }

//     void OnTriggerEnter2D(Collider2D other)
//     {
//          if (other.CompareTag("ComboPowerup"))
//          {
//               PlaySound();

//               // Spawn and play particle effect
//               if (particleEffect)
//               {
//                    ParticleSystem particles = Instantiate(particleEffect, other.transform.position, Quaternion.identity);
//                    particles.Play();
//                    Destroy(particles.gameObject, particles.main.duration + particles.main.startLifetime.constantMax);
//               }

//               breakBrick.scorePerBrick += 10;
//               comboText.text = breakBrick.scorePerBrick.ToString();

//               Destroy(other.gameObject);
//          }
//     }

//     private void PlaySound()
//     {
//          // Play the comboPowerup sound
//          if (audioSource && powerSound)
//               audioSource.PlayOneShot(powerSound);
//     }
//}
