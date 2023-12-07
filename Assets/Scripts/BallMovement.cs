using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5;
    Rigidbody rb;
    void Start()
{
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 vector3 = new Vector3(horizontalInput * speed, 0, verticalInput * speed);
        rb.AddForce(vector3);
    }
}
