using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad = "LevelSelector";

    public SceneFader sceneFader;

    public void Play ()
    {
        sceneFader.FadeTo(levelToLoad);
    }
    
    public void Quit ()
    {
        Debug.Log("Exciting...");
        Application.Quit();
    }
}
