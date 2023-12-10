using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallJump : MonoBehaviour
{
    public float jumpForce = 3;
    public Rigidbody rb;
    public bool isOnTheGround = true;

    void Start()
    {
        if (rb == null) 
            rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
         if (isOnTheGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isOnTheGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }
    }
}
