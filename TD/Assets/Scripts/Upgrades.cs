using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{

    public int ClickPWR;
    public Text clickamount;
    public Button UpgradeClickPWRButton;
    public int Gems;
    public Text GemsAmount;

    public void Start()
    {
        if (ClickPWR == 0)
        {
            ClickPWR = 1;
        }
        clickamount.text = ClickPWR.ToString();
        GemsAmount.text = Gems.ToString();
        UpgradeClickPWRButton.interactable = false;
        Gems = PlayerPrefs.GetInt("Gems");
        ClickPWR = PlayerPrefs.GetInt("Click");

        GemsAmount.text = PlayerPrefs.GetInt("Gems").ToString();
        clickamount.text = PlayerPrefs.GetInt("Click").ToString();

        if (Gems < 1)
        {
            UpgradeClickPWRButton.interactable = false;
        }
        if (Gems >= 1)
        {
            UpgradeClickPWRButton.interactable = true;
        }
    }

    public void Update()
    {        
    }

    public void ClickpwrUpgrade ()
    {
        if (Gems < 1)
        {
            UpgradeClickPWRButton.interactable = false;
        }
        if (Gems >= 1)
        {
            UpgradeClickPWRButton.interactable = true;
        }

        if (Gems >= 1)
        {
            ClickPWR++;
            Debug.Log(ClickPWR);
            PlayerPrefs.SetInt("Click", ClickPWR);
            Gems--;
            PlayerPrefs.SetInt("Gems", Gems);
            clickamount.text = ClickPWR.ToString();
            GemsAmount.text = Gems.ToString();
        }
        
    }

    public void GetGems()
    {
        Gems++;
        Debug.Log(Gems);
        PlayerPrefs.SetInt("Gems", Gems);

        clickamount.text = ClickPWR.ToString();
        GemsAmount.text = Gems.ToString();
    }
}
