using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCube : MonoBehaviour
{
    [SerializeField] float exitTimer = 5;
    private float time;
    private Outline outline;
    private bool isEntered = false;

    private void Start()
    {
        outline = GetComponent<Outline>();
    }

    private void OnTriggerEnter(Collider other)
    {
        isEntered = true;
        Debug.Log("Player entered the collider");

        time = 0;
        outline.OutlineWidth = 6;
    }

    private void Update()
    {
        if (isEntered == true)
        {
            time += Time.deltaTime;
            Debug.Log(time);

            if (time >= exitTimer)
            {
                Debug.Log($"{exitTimer} seconds over");

                SceneManager.LoadScene("Main Menu");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isEntered = false;
            Debug.ClearDeveloperConsole();
            Debug.Log("Player left the collider, timer reseted");

            time = 0;
            outline.OutlineWidth = 1;
        }
    }
}