using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class CharacterChanger : MonoBehaviour
{
    private SpriteRenderer currentSkin;

    private List<ScriptableCustomization> charactersList;

    private ScriptableCustomization blueMonster;
    private ScriptableCustomization greenMonster;
    private ScriptableCustomization orangeMonster;
    private ScriptableCustomization pinkMonster;
    private ScriptableCustomization purpleMonster;

    private int skinIndex = 0;

    private void Start()
    {
        charactersList = new List<ScriptableCustomization>();

        blueMonster = Resources.Load<ScriptableCustomization>("Skins/BlueMonster");
        greenMonster = Resources.Load<ScriptableCustomization>("Skins/GreenMonster");
        orangeMonster = Resources.Load<ScriptableCustomization>("Skins/OrangeMonster");
        pinkMonster = Resources.Load<ScriptableCustomization>("Skins/PinkMonster");
        purpleMonster = Resources.Load<ScriptableCustomization>("Skins/PurpleMonster");

        charactersList.Add(blueMonster);
        charactersList.Add(greenMonster);
        charactersList.Add(orangeMonster);
        charactersList.Add(pinkMonster);
        charactersList.Add(purpleMonster);

        if (charactersList.Count > 0)
        {
            currentSkin = gameObject.GetComponent<SpriteRenderer>();
            currentSkin.sprite = charactersList[skinIndex].Skin;
        }
    }
    public void SetNextSkin()
    {
        if (charactersList.Count > 0)
        {
            skinIndex++;
            if (skinIndex >= charactersList.Count)
            {
                skinIndex = 0;
            }
            currentSkin.sprite = charactersList[skinIndex].Skin;
        }
    }
    public void SetPreviousSkin()
    {
        if (charactersList.Count > 0)
        {
            skinIndex--;
            if (skinIndex < 0)
            {
                skinIndex = charactersList.Count - 1;
            }
            currentSkin.sprite = charactersList[skinIndex].Skin;
        }
    }
}
