using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class DebugGUI : MonoBehaviour
{
    [SerializeField] SkinManager skinManager;

    private SpriteRenderer spriteRenderer;
    private int skinIndex;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        skinIndex = Array.IndexOf(skinManager.skins, skinManager.GetSelectedSkin());
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
            if (skinManager.skins.Length > 0)
            {
                skinIndex++;

                if (skinIndex >= skinManager.skins.Length)
                {
                    skinIndex = 0;
                }
                skinManager.SelectSkin(skinIndex);
                spriteRenderer.sprite = skinManager.GetSelectedSkin().sprite;
            }
        }
    }   
    private void DrawPrevSkinButton()
    {
        if (GUI.Button(new Rect(10, 50, 40, 20), "Prev"))
        {
            if (skinManager.skins.Length > 0)
            {
                skinIndex--;

                if (skinIndex < 0)
                {
                skinIndex = skinManager.skins.Length - 1;
                }
                skinManager.SelectSkin(skinIndex);
                spriteRenderer.sprite = skinManager.GetSelectedSkin().sprite;
            }
        }
    }
}
