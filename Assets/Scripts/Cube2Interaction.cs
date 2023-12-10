using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Cube2Interaction : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float jumpForce = 100;

    private bool isEntered = false;
    private bool isOnTheGround = true;

    private Outline outline;
    private void Start()
    { 
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        if (outline == null) 
            outline = GetComponent<Outline>();
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

            outline.OutlineWidth = 6;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            isEntered = false;

            outline.OutlineWidth = 0;
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