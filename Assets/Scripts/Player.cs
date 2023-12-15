using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private Rigidbody rb;

    private List<ICubeInteraction> cubes;
    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        cubes = new List<ICubeInteraction>();
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(h * speed, 0, v * speed));

        CubeJumpOnCommand();
    }
    private void CubeJumpOnCommand()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (var cube in cubes)
            {
                cube.CubeJump();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        cubes.Add(other.GetComponent<ICubeInteraction>());

        foreach (var cube in cubes)
        {
            cube.ChangeVisual();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        foreach (var cube in cubes)
        {
            cube.BackInitialVisual();
        }
        cubes.Remove(other.GetComponent<ICubeInteraction>());
    }
}