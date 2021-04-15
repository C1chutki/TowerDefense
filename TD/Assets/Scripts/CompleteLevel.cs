using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";
    public string nextLevel = "Level02";
    public GameObject GemGainText;

    GameManager gamemanager;
    void Start()
    {
        GemGainText.SetActive(false);
        gamemanager = FindObjectOfType<GameManager>();
        if (gamemanager.WinGame == 0)
        {
            GemGainText.SetActive(true);
        }
    }

    public void Continue()
    {
        Debug.Log("Level won!");
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
