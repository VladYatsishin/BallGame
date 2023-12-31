using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DebugGUI : MonoBehaviour
{
    private CharacterChanger characterChanger;
    
    private void Start()
    {
        characterChanger = GetComponent<CharacterChanger>();
    }
    
    private void OnGUI()
    {
        DrawDebugWindow();
        DrawCustomiationLabel();
        DrawNextSkinButton();
        DrawPrevSkinButton();
    }
    
    private void DrawDebugWindow()
    {
        GUI.Box(new Rect(5, 5, 100, 70), "Debug");
        GUI.backgroundColor = Color.gray;
    }
    
    private void DrawCustomiationLabel()
    {
        GUI.Label(new Rect(15, 25, 90, 25), "Customization");
    }
    
    private void DrawNextSkinButton()
    {
        if (GUI.Button(new Rect(60, 50, 40, 20), "Next"))
        {
            characterChanger.SetNextSkin();
        }
    }
    
    private void DrawPrevSkinButton()
    {
        if (GUI.Button(new Rect(10, 50, 40, 20), "Prev"))
        {
            characterChanger.SetPreviousSkin();
        }
    }
}

