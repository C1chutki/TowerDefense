using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleTurretUpgrade : MonoBehaviour
{
    Upgrades upgrades;
    

    [Header("Simple Turret Upgrade")]
    public int upgradeCost1;
    public int upgradeCost2;
    public int upgradeCost3;
    public int bulletDMG;
    public Text upgradeCosttxt;
    public Text upgradeDMG;
    public Button UpgradeButton1;
    public Button UpgradeButton2;
    public Button UpgradeButton3;

    public GameObject turret;
    public GameObject bullet;
    


    // Start is called before the first frame update
    void Start()
    {
        upgrades = FindObjectOfType<Upgrades>();

        //turret.GetComponent<Turret>().bulletdmg = 100;
        bullet.GetComponent<Bullet>().damage = 100;
        

        //upgradeCost1 = PlayerPrefs.GetInt("SimpleDMGupg");
        //bulletDMG = PlayerPrefs.GetInt("bulletDMG");

        //upgradeCosttxt.text = PlayerPrefs.GetInt("SimpleDMGupg").ToString();
        //upgradeDMG.text = PlayerPrefs.GetInt("bulletDMG").ToString();

        UpgradeDMGCheck();
        //upgradeCosttxt.text = upgradeCost1 + "G";


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Skrypt sprawdzaj¹cy czy staæ u¿ytkownika na ulepszenie
    public void UpgradeDMGCheck()
    {
        //if (upgrades.Gems < upgradeCost1)
        //{
        //    UpgradeButton1.interactable = false;
        //}
        //if (upgrades.Gems >= upgradeCost1)
        //{
        //    UpgradeButton1.interactable = true;
        //}
    }

    public void DMGUpgrade(TurretBlueprint turretBlueprint)
    {

    }
}
