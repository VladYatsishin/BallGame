using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeInteraction : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float jumpForce = 100;

    private bool isEntered = false;
    private bool isOnTheGround = true;

    private Color initialColor;
    private void Start()
    {
        if (rb == null)
        rb = GetComponent<Rigidbody>();

        initialColor = GetComponent<Renderer>().material.color;
    }
    private void Update()
    {
       if (isEntered == true && isOnTheGround && Input.GetKeyDown(KeyCode.E))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isOnTheGround = false;
        } 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            isEntered = true;
            transform.GetComponent<Renderer>().material.color = Color.red;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            isEntered = false;
            transform.GetComponent<Renderer>().material.color = initialColor;
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
