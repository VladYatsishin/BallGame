using UnityEngine;

[CreateAssetMenu(fileName = "SkinManager", menuName = "Skin Manager")]
public class SkinManager : ScriptableObject
{
    public Skin[] skins;

    private const string prefix = "Skin_";
    private const string selectedSkin = "Selected skin";

    public void SelectSkin(int skinIndex)
    {
        PlayerPrefs.SetInt(selectedSkin, skinIndex);
    }

    public Skin GetSelectedSkin()
    {
        int skinIndex = PlayerPrefs.GetInt(selectedSkin);
        if (skinIndex >= 0 && skinIndex < skins.Length)
        {
            return skins[skinIndex];
        }
        else
        {
            return null;
        }
    }

    public void Unlock(int skinIndex)
    {
        PlayerPrefs.SetInt(prefix + skinIndex, 1);
    }

    public bool IsUnlocked(int skinIndex)
    {
        return PlayerPrefs.GetInt(prefix + skinIndex, 0) == 1;
    }
}
