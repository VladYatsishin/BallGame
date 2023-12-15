using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Cube2 : MonoBehaviour, ICubeInteraction
{
    private Rigidbody rb;

    [SerializeField] private float jumpForce = 100;

    public bool isOnTheGround = true;
    public bool isEntered = false;
    private Outline outline;
    private void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        outline = GetComponent<Outline>();
    }
    public void ChangeVisual()
    {
        isEntered = true;
        outline.OutlineWidth = 6;
    }
    public void BackInitialVisual()
    {
        isEntered = false;
        outline.OutlineWidth = 0; 
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
