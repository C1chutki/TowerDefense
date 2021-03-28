using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public GameObject circleRange;
    private Node target;
    public Button upgradeButton;
    public Text UpgradeCost;
    public Text SellAmount;

    public Shop shop;

    public void SetTarget (Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();


        //shop = GetComponent<Shop>();
        //shop.TurretName.text = target.name;
        //shop.dmg.text = target.bulletPrefab.GetComponent<Bullet>().damage.ToString();
        //shop.speed.text = "1";
        //shop.range.text = target.range.ToString();
        //shop.slow.text = "0";
        //shop.AOE.text = "0";

        if (!target.isUpgraded)
        {
            UpgradeCost.text = "$" + target.turretBlueprint.UpgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            UpgradeCost.text = "Upgraded";
            upgradeButton.interactable = false;
        }

        SellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

        ui.SetActive(true);
        
        circleRange.SetActive(true);
        
        circleRange.transform.localScale = new Vector3(target.turretBlueprint.turretRange, target.turretBlueprint.turretRange, 0f);

    }

    public void Hide()
    {
        ui.SetActive(false);
        circleRange.SetActive(false);
    }

    public void Upgrade()
    {
        Debug.Log("Upgrade");
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell ()
    {
        Debug.Log("sell");
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
