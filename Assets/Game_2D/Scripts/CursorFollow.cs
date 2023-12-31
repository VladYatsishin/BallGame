using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour
{
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