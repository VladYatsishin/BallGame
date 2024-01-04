using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SkinManager skinManager;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = skinManager.GetSelectedSkin().sprite;
    }

    private void Update ()
    {
        FollowIfPressed();
    }

    private void FollowIfPressed()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            transform.position = new Vector2(cursorPosition.x, cursorPosition.y);
        }
    }
}