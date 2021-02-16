using UnityEngine;
using UnityEngine.UI;


public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    Turret turret;
    private Node target;
    public Button upgradeButton;
    public Text UpgradeCost;
    public Text SellAmount;

    public void SetTarget (Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

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
        turret.ShowRange();
        
    }

    public void Hide()
    {
        ui.SetActive(false);
        turret.HideRange();
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell ()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
