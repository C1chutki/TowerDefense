using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    public int gems;
    public Upgrades upgrades;
    

    void Start ()
    {
        GameIsOver = false;
        upgrades = FindObjectOfType<Upgrades>();
        
    }

    void Update()
    {
        if (GameIsOver)
            return;

       if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame ()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gems = PlayerPrefs.GetInt("Gems");
        gems++;
        Debug.Log("You got one Gem!");
        Debug.Log(gems);
        PlayerPrefs.SetInt("Gems", gems);
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
