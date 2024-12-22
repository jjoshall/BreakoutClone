using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
     public float speed = 10.0f;
     private Rigidbody2D rb;
     public bool hitPaddle = false;
     public BreakBrick BreakBrickScript;

     public TextMeshProUGUI comboNum; // Reference to the TextMeshPro text

     public AudioClip bounceSound; // Bounce sound
     private AudioSource audioSource;

     public ParticleSystem particleEffect; // Particle effect prefab

     void Start()
     {
          audioSource = GetComponent<AudioSource>();
          rb = GetComponent<Rigidbody2D>();

          // Dynamically find the comboNum object in the scene
          if (comboNum == null)
          {
               comboNum = GameObject.Find("ComboNum").GetComponent<TextMeshProUGUI>();
          }

          // Launch the ball in downwards direction
          rb.velocity = Vector2.down * 5;
     }

     private void OnCollisionEnter2D(Collision2D collision)
     {
          if (collision.gameObject.CompareTag("Player"))
          {
               PlaySound();

               // Set hitPaddle to true and reset it after 0.1 seconds
               // This is for extra points if the ball hits multiple bricks before hitting the paddle
               hitPaddle = true;
               BreakBrickScript.bricksHit = 0;
               comboNum.text = "0";
               StartCoroutine(MakeHitPaddleFalse());

               // Spawn and play particle effect at the collision point
               if (particleEffect)
               {
                    ContactPoint2D contact = collision.GetContact(0);
                    ParticleSystem particles = Instantiate(particleEffect, contact.point, Quaternion.identity);
                    particles.Play();
                    Destroy(particles.gameObject, particles.main.duration + particles.main.startLifetime.constantMax);
               }

               // Adjust ball direction based on where it hit the paddle
               Transform paddle = collision.transform;
               float paddleWidth = paddle.GetComponent<BoxCollider2D>().bounds.size.x;
               float hitPoint = collision.GetContact(0).point.x - paddle.position.x;
               float offset = hitPoint / (paddleWidth / 2);

               Vector2 direction = new Vector2(offset, 1).normalized;
               rb.velocity = direction * speed;
          }
          else if (collision.gameObject.CompareTag("Wall"))
          {
               PlaySound();

               // Spawn and play particle effect
               if (particleEffect)
               {
                    ContactPoint2D contact = collision.GetContact(0);
                    ParticleSystem particles = Instantiate(particleEffect, contact.point, Quaternion.identity);
                    particles.Play();
                    Destroy(particles.gameObject, particles.main.duration + particles.main.startLifetime.constantMax);
               }
          }
     }

     private IEnumerator MakeHitPaddleFalse()
     {
          yield return new WaitForSeconds(0.1f);
          hitPaddle = false;
     }

     private void PlaySound()
     {
          // Play bounce sound
          if (audioSource && bounceSound)
               audioSource.PlayOneShot(bounceSound);
     }
}
