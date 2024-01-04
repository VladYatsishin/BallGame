using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private SkinManager skinManager;

    [SerializeField] private Image selectedSkin;
    [SerializeField] private TMP_Text coinsText;
    void Update()
    {
        coinsText.text = "Coins:" + PlayerPrefs.GetInt("Coins", 0);
        selectedSkin.sprite = skinManager.GetSelectedSkin().sprite;
    }
}
