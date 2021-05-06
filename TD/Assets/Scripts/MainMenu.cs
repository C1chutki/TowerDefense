using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad = "LevelSelector";
    public string Upgrade = "UpgradeScene";
    public string LoadMenu = "MainMenu";


    public SceneFader sceneFader;

    public void LevelToLoad ()
    {
        sceneFader.FadeTo(levelToLoad);
        Debug.Log("Load level selector");
    } 

    public void Upgrades ()
    {
        sceneFader.FadeTo(Upgrade);
        Debug.Log("Load upgrade scene");
    } 

    public void Menu ()
    {
        sceneFader.FadeTo(LoadMenu); 
        Debug.Log("Load menu");
    } 
    
    public void Quit ()
    {
        Debug.Log("Exciting...");
        Application.Quit();
    }
}
