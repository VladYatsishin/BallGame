using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        BackToMainMenu();
    }
    private void CubeJumpOnCommand()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            /*foreach (var cube in cubes)
            {
                cube.CubeJump();
            }*/

            for (int i = 0; i < cubes.Count; i++)
            {
                var cube = cubes[i];
                cube.CubeJump();
            }
        }
    }

    private void BackToMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ICubeInteraction>(out var cube))
        { 
            cubes.Add(cube);
            cube.ChangeVisual();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (cubes.Count != 0)
        {
            if (other.TryGetComponent<ICubeInteraction>(out var cube))
            {
                cube.BackInitialVisual();
                cubes.Remove(cube);
            }
        }
    }
}