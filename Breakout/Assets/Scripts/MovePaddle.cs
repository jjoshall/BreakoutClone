using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{
     public float speed = 10.0f;
     public float boundary = 7.5f;

     void Update()
     {
          MyInput();
     }

     private void MyInput()
     {
          float horizontal = Input.GetAxisRaw("Horizontal");

          transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);

          float clampedX = Mathf.Clamp(transform.position.x, -boundary, boundary);
          transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
     }
}
