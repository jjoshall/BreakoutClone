using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallsPowerup : MonoBehaviour
{
     // Use an object pool for bringing in more balls
     
     public AudioClip powerSound; // Sound for breaking bricks
     private AudioSource audioSource;

     public ParticleSystem particleEffect; // Particle effect prefab
     public GameObject ballPrefab; // Ball prefab

     void Start()
     {
          audioSource = GetComponent<AudioSource>();
     }

     void OnTriggerEnter2D(Collider2D other)
     {
          if (other.CompareTag("Powerup"))
          {
               PlaySound();

               // Spawn and play particle effect
               if (particleEffect)
               {
                    ParticleSystem particles = Instantiate(particleEffect, other.transform.position, Quaternion.identity);
                    particles.Play();
                    Destroy(particles.gameObject, particles.main.duration + particles.main.startLifetime.constantMax);
               }

               // Spawn 1 more ball after hitting the powerup
               Instantiate(ballPrefab, new Vector3(1, 0, 0), Quaternion.identity);

               Destroy(other.gameObject);
          }
     }

     private void PlaySound()
     {
          // Play the powerup sound
          if (audioSource && powerSound)
               audioSource.PlayOneShot(powerSound);
     }
}
