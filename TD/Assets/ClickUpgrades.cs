using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickUpgrades : MonoBehaviour
{
    Upgrades upgrades;

    [Header("Clicking")]
    public int ClickPWRCost;
    public int ClickPWR;
    public Text clickamount;
    public Text ClickPWRCostTEXT;
    public Button UpgradeClickPWRButton;

    // Start is called before the first frame update
    void Start()
    {
        upgrades = FindObjectOfType<Upgrades>();

        //Get all PlayerPrefs
        ClickPWR = PlayerPrefs.GetInt("Click");
        ClickPWRCost = PlayerPrefs.GetInt("ClickPWRCost");

        if (ClickPWRCost == 0)
        {
            Debug.Log(ClickPWRCost);
            ClickPWRCost = 1;
            PlayerPrefs.SetInt("ClickPWRCost", ClickPWRCost);
            Debug.Log(ClickPWRCost);
        }


        clickamount.text = ClickPWR.ToString();

        //Set PlayerPrefs amount to UI
        clickamount.text = PlayerPrefs.GetInt("Click").ToString();
        ClickPWRCostTEXT.text = PlayerPrefs.GetInt("ClickPWRCost").ToString();

        ClickpwrCheck();
        ClickPWRCostTEXT.text = ClickPWRCost + "G";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Skrypt sprawdzaj¹cy czy staæ u¿ytkownika na ulepszenie
    public void ClickpwrCheck()
    {
        if (upgrades.Gems < ClickPWRCost)
        {
            UpgradeClickPWRButton.interactable = false;
            ChangeColor();
        }
        if (upgrades.Gems >= ClickPWRCost)
        {
            UpgradeClickPWRButton.interactable = true;
        }
    }

    public void ChangeColor()
    {
        // Zmienia kolor przycisku na czerwony
        var newColorBlock = UpgradeClickPWRButton.colors;
        newColorBlock.disabledColor = new Color(1, 0, 0, 0.1f);
        UpgradeClickPWRButton.colors = newColorBlock;
    }

    //Skrypt ulepszaj¹cy klik
    public void ClickpwrUpgrade()
    {
        ClickpwrCheck();

        if (upgrades.Gems >= ClickPWRCost)
        {
            //ulepszanie kliku
            ClickPWR++;
            upgrades.Gems -= ClickPWRCost;
            ClickPWRCost++;

            //aktyalizacja ui
            clickamount.text = ClickPWR.ToString();
            upgrades.GemsAmount.text = upgrades.Gems.ToString();
            ClickPWRCostTEXT.text = ClickPWRCost + "G";

            //zapis do PlayerPrefs
            PlayerPrefs.SetInt("Click", ClickPWR);
            PlayerPrefs.SetInt("Gems", upgrades.Gems);
            PlayerPrefs.SetInt("ClickPWRCost", ClickPWRCost);

            //sprawdzanie czy po zakupie u¿ytkownika staæ na kolejne ulepszenie
            ClickpwrCheck();
        }

    }
}