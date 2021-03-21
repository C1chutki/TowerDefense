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

    public void StandartTurretInfo ()
    {
        TurretName.text = "Standard Turret";
        dmg.text = "1";
        speed.text = "1";
        range.text = "10";
        slow.text = "0";
        AOE.text = "0";
    }

    public void UpgradedStandartTurretInfo ()
    {
        TurretName.text = "Standard Turret v2";
        dmg.text = "1";
        speed.text = "1";
        range.text = "10";
        slow.text = "0";
        AOE.text = "0";
    }

    public void RocketTurretInfo ()
    {
        TurretName.text = "Rocket Luncher";
        dmg.text = "1";
        speed.text = "1";
        range.text = "10";
        slow.text = "0";
        AOE.text = "0";
    }

    public void UpgradedRocketTurretInfo ()
    {
        TurretName.text = "Rocket Luncher v2";
        dmg.text = "1";
        speed.text = "1";
        range.text = "10";
        slow.text = "0";
        AOE.text = "0";
    }

    public void LaserTurretInfo ()
    {
        TurretName.text = "Laser";
        dmg.text = "1";
        speed.text = "1";
        range.text = "10";
        slow.text = "0";
        AOE.text = "0";
    }
    public void UpgradedLaserTurretInfo ()
    {
        TurretName.text = "Laser v2";
        dmg.text = "1";
        speed.text = "1";
        range.text = "10";
        slow.text = "0";
        AOE.text = "0";
    }

    public void SnipertTurretInfo ()
    {
        TurretName.text = "Sniper Turret";
        dmg.text = "1";
        speed.text = "1";
        range.text = "10";
        slow.text = "0";
        AOE.text = "0";
    }
    public void UpgradedSnipertTurretInfo ()
    {
        TurretName.text = "Sniper Turret v2";
        dmg.text = "1";
        speed.text = "1";
        range.text = "10";
        slow.text = "0";
        AOE.text = "0";
    }

    public void MiniGunTurretInfo ()
    {
        TurretName.text = "MiniGun";
        dmg.text = "1";
        speed.text = "1";
        range.text = "10";
        slow.text = "0";
        AOE.text = "0";
    }
    public void UpgradedMiniGunTurretInfo ()
    {
        TurretName.text = "MiniGun v2";
        dmg.text = "1";
        speed.text = "1";
        range.text = "10";
        slow.text = "0";
        AOE.text = "0";
    }



    public void SelectStandardTurret ()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
        StandartTurretInfo();
    }
    public void SelectMissleLuncher ()
    {
        Debug.Log("MissleLuncher Turret Selected");
        buildManager.SelectTurretToBuild(missileLuncher);
        RocketTurretInfo();
    }
    public void SelectLaserBeamer ()
    {
        Debug.Log("LaserBeamer Turret Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
        LaserTurretInfo();
    }
    public void SelectMiniGun ()
    {
        Debug.Log("LaserBeamer Turret Selected");
        buildManager.SelectTurretToBuild(MiniGun);
        MiniGunTurretInfo();
    }
    public void SelectSniper ()
    {
        Debug.Log("LaserBeamer Turret Selected");
        buildManager.SelectTurretToBuild(Sniper);
        SnipertTurretInfo();
    }
}