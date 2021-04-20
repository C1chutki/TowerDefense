using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [Header("Gems")]
    public int Gems;
    public Text GemsAmount;

    public void Start()
    {
        GemsAmount.text = Gems.ToString();
        Gems = PlayerPrefs.GetInt("Gems");
        GemsAmount.text = PlayerPrefs.GetInt("Gems").ToString();
    }

    public void Update()
    {      
        
    }

    //Otrzymanie gema za obejrzenie reklamy
    public void GetGems()
    {
        Gems++;
        Debug.Log(Gems);
        PlayerPrefs.SetInt("Gems", Gems);
        GemsAmount.text = Gems.ToString();
    }
}
