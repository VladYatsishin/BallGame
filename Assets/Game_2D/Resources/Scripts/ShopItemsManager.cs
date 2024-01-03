using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemsManager : MonoBehaviour
{
    [SerializeField] private SkinManager skinManager;
    [SerializeField] private int skinIndex;
    [SerializeField] private Button buyButton;
    [SerializeField] private TMP_Text priceText;

    private Skin skin;

    void Start()
    {
        PlayerPrefs.SetInt("Coins", 100);

        skin = skinManager.skins[skinIndex];

        if (skinManager.IsUnlocked(skinIndex))
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            priceText.text = skin.price.ToString();
        }
    }

    public void OnBuyButtonPressed()
    {
        int coins = PlayerPrefs.GetInt("Coins", 0);

        if (coins >= skin.price && !skinManager.IsUnlocked(skinIndex))
        {
            PlayerPrefs.SetInt("Coins", coins - skin.price);
            skinManager.Unlock(skinIndex);
            buyButton.gameObject.SetActive(false);
            skinManager.SelectSkin(skinIndex);
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    public void OnSkinPressed()
    {
        if (skinManager.IsUnlocked(skinIndex))
        {
            skinManager.SelectSkin(skinIndex);
        }
    }
}
