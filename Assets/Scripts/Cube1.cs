using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube1 : MonoBehaviour, ICubeInteraction
{
    private Rigidbody rb;

    [SerializeField] private float jumpForce = 100;

    public bool isOnTheGround = true;
    public bool isEntered = false;

    private Renderer cubeRenderer;

    private Color initialColor;
    private void Start()
    {
        if (rb == null) 
            rb = GetComponent<Rigidbody>();

        if (cubeRenderer == null)
            cubeRenderer = rb.GetComponent<Renderer>();

        initialColor = cubeRenderer.material.color;
    }
    public void ChangeVisual()
    {
        isEntered = true;
        cubeRenderer.material.color = Color.red;
    }
    public void BackInitialVisual()
    {
        isEntered = false;
        cubeRenderer.material.color = initialColor;
    }
    public void CubeJump()
    {
        if (isEntered = true && isOnTheGround)
        {
            isOnTheGround = false;
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
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
