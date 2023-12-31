using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "PlayerCustomization", menuName = "ScriptableObjects/PlayerCustomization")]
public class ScriptableCustomization : ScriptableObject
{
    public Sprite Skin;
}
