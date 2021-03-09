using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLuncher;
    public TurretBlueprint laserBeamer;
    public TurretBlueprint MiniGun;
    public TurretBlueprint Sniper;

    public Text TurretName;
    public Text dmg;
    public Text speed;
    public Text range;
    public Text slow;
    public Text AOE;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret ()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
        TurretName.text = "Standard Turret";
        dmg.text = "50";
        speed.text = "1";
        range.text = "10";
        slow.text = "0";
        AOE.text = "0";
    }
    public void SelectMissleLuncher ()
    {
        Debug.Log("MissleLuncher Turret Selected");
        buildManager.SelectTurretToBuild(missileLuncher);
        TurretName.text = "Standard Turret";
        dmg.text = "50";
        speed.text = "1";
        range.text = "10";
        slow.text = "0";
        AOE.text = "0";
    }
    public void SelectLaserBeamer ()
    {
        Debug.Log("LaserBeamer Turret Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
        TurretName.text = "Standard Turret";
        dmg.text = "50";
        speed.text = "1";
        range.text = "10";
        slow.text = "0";
        AOE.text = "0";
    }
    public void SelectMiniGun ()
    {
        Debug.Log("LaserBeamer Turret Selected");
        buildManager.SelectTurretToBuild(MiniGun);
        TurretName.text = "Standard Turret";
        dmg.text = "50";
        speed.text = "1";
        range.text = "10";
        slow.text = "0";
        AOE.text = "0";
    }
    public void SelectSniper ()
    {
        Debug.Log("LaserBeamer Turret Selected");
        buildManager.SelectTurretToBuild(Sniper);
        TurretName.text = "Standard Turret";
        dmg.text = "50";
        speed.text = "1";
        range.text = "10";
        slow.text = "0";
        AOE.text = "0";
    }
}