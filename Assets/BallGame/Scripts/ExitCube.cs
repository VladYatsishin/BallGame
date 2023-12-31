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
        time = 0;
        outline.OutlineWidth = 6;

        Debug.Log("Player entered the collider");
    }

    private void Update()
    {
        if (isEntered == true)
        {
            time += Time.deltaTime;
            Debug.Log(time);
        }

        if (time >= exitTimer)
        {
            SceneManager.LoadScene("Main Menu");
            Debug.Log($"{exitTimer} seconds over");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isEntered = false;
            time = 0;
            outline.OutlineWidth = 1;

            Debug.ClearDeveloperConsole();
            Debug.Log("Player left the collider, timer reseted");
        }
    }
}