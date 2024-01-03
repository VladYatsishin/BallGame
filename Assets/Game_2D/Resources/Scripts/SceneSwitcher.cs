using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void EnterShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void EnterGame()
    {
        SceneManager.LoadScene("Game2D");
    }
}
