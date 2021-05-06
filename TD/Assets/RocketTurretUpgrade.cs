using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketTurretUpgrade : MonoBehaviour
{
    public Upgrades upgrades;

    public int upgradeCost1;
    public int upgradeCost2;
    public int upgradeCost3;

    public int UpgradeLevel2;

    public Button UpgradeButton1;
    public Button UpgradeButton2;
    public Button UpgradeButton3;

    public GameObject turret;
    public GameObject bullet;
    public GameObject[] tab = new GameObject[2];
    public SpriteRenderer arrow1;
    public SpriteRenderer arrow2;
    public float DMG;
    public float Range;
    public float AOE;


    public ClickUpgrades click;

    //turret.GetComponent<Turret>().bulletdmg = 100;
    //bullet.GetComponent<Bullet>().damage = 100;


    // Start is called before the first frame update
    void Start()
    {
        UpgradeLevel2 = PlayerPrefs.GetInt("RocketUpgradeLevel");
        upgrades.Gems = PlayerPrefs.GetInt("Gems");
        DMG = PlayerPrefs.GetFloat("Rocketbulletdmg");
        Range = PlayerPrefs.GetFloat("Rocketrange");
        AOE = PlayerPrefs.GetFloat("RocketAOE");

        if (DMG == 0)
        {
            DMG = 1;

            PlayerPrefs.SetFloat("Rocketbulletdmg", DMG);
        }


        if (UpgradeLevel2 == 0)
        {
            UpgradeLevel2 = 1;
            PlayerPrefs.SetInt("RocketUpgradeLevel", UpgradeLevel2);
        }


        if (UpgradeLevel2 > 1 && UpgradeLevel2 < 4)
        {
            for (int i = 0; i <= UpgradeLevel2 - 2; i++)
            {
                tab[i].GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 0.1f);
            }

        }
        else if (UpgradeLevel2 >= 4)
        {
            for (int i = 0; i < 2; i++)
            {
                tab[i].GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 0.1f);
            }
        }
        upgradecheck();
    }



    // Update is called once per frame
    void Update()
    {
        //upgradecheck();
    }

    //Skrypt sprawdzaj¹cy czy staæ u¿ytkownika na ulepszenie
    public void upgradecheck()
    {
        click.ClickpwrCheck();

        UpgradeButton1.interactable = false;
        UpgradeButton2.interactable = false;
        UpgradeButton3.interactable = false;


        //if (upgrades.Gems < upgradeCost1 && upgrades.Gems < upgradeCost2 && upgrades.Gems < upgradeCost3)
        //{
        //    UpgradeButton1.interactable = false;
        //    UpgradeButton2.interactable = false;
        //    UpgradeButton3.interactable = false;
        //}

        if (UpgradeLevel2 == 1 && upgrades.Gems >= upgradeCost1)
        {
            UpgradeButton1.interactable = true;
            //UpgradeButton2.interactable = false;
            //UpgradeButton3.interactable = false;
        }

        if (UpgradeLevel2 == 2 && upgrades.Gems >= upgradeCost2)
        {
            //UpgradeButton1.interactable = false;
            UpgradeButton2.interactable = true;
            //UpgradeButton3.interactable = false;
        }

        if (UpgradeLevel2 == 3 && upgrades.Gems >= upgradeCost3)
        {
            //UpgradeButton1.interactable = false;
            //UpgradeButton2.interactable = false;
            UpgradeButton3.interactable = true;
        }

        if (UpgradeButton1.interactable == false)
        {
            var button1color = UpgradeButton1.colors;
            button1color.disabledColor = new Color(1, 0, 0, 0.55f);
            UpgradeButton1.colors = button1color;
        }

        if (UpgradeButton2.interactable == false)
        {
            var button2color = UpgradeButton2.colors;
            button2color.disabledColor = new Color(1, 0, 0, 0.55f);
            UpgradeButton2.colors = button2color;
        }

        if (UpgradeButton3.interactable == false)
        {
            var button3color = UpgradeButton3.colors;
            button3color.disabledColor = new Color(1, 0, 0, 0.55f);
            UpgradeButton3.colors = button3color;
        }
    }

    public void UpgradeOne()
    {
        upgradecheck();

        if (upgrades.Gems >= upgradeCost1)
        {
            DMG = bullet.GetComponent<Bullet>().damage = 1.5f;
            PlayerPrefs.SetFloat("Rocketbulletdmg", DMG);

            upgrades.Gems -= upgradeCost1;
            UpgradeLevel2++;

            upgrades.GemsAmount.text = upgrades.Gems.ToString();

            PlayerPrefs.SetInt("Gems", upgrades.Gems);
            PlayerPrefs.SetInt("RocketUpgradeLevel", UpgradeLevel2);

            arrow1.color = new Color(0, 1, 0, 0.1f);

            upgradecheck();

        }
    }

    public void Upgradetwo()
    {
        upgradecheck();

        if (upgrades.Gems >= upgradeCost2)
        {
            Range = turret.GetComponent<Turret>().range = 12;
            PlayerPrefs.SetFloat("Rocketrange", Range);

            upgrades.Gems -= upgradeCost2;
            UpgradeLevel2++;

            upgrades.GemsAmount.text = upgrades.Gems.ToString();

            PlayerPrefs.SetInt("Gems", upgrades.Gems);
            PlayerPrefs.SetInt("RocketUpgradeLevel", UpgradeLevel2);

            arrow2.color = new Color(0, 1, 0, 0.1f);

            upgradecheck();
        }
    }

    public void Upgradethree()
    {
        upgradecheck();

        if (upgrades.Gems >= upgradeCost3)
        {
            AOE = bullet.GetComponent<Bullet>().explosionRadius = 7;
            PlayerPrefs.SetFloat("RocketAOE", AOE);

            upgrades.Gems -= upgradeCost3;
            UpgradeLevel2++;

            upgrades.GemsAmount.text = upgrades.Gems.ToString();

            PlayerPrefs.SetInt("Gems", upgrades.Gems);
            PlayerPrefs.SetInt("RocketUpgradeLevel", UpgradeLevel2);

            upgradecheck();
        }
    }
}
