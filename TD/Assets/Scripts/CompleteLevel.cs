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
    public Text gemgaintext;
    public GameManager gamemanager;

    void Start()
    {
        gemgaintext.text = "+" + gamemanager.wingames.ToString() + " Gems";
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
