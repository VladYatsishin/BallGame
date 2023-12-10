using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody rb;

    void Start()
{
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        rb.AddForce(new Vector3(horizontalInput * speed, 0, verticalInput * speed));
    }
}
