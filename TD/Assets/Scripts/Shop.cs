using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("BluePrints")]
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLuncher;
    public TurretBlueprint laserBeamer;
    public TurretBlueprint MiniGun;
    public TurretBlueprint Sniper;

    [Header("TurretInfo")]
    public Text TurretName;
    public Text dmg;
    public Text speed;
    public Text range;
    public Text slow;
    public Text AOE;

    public Turret TurretScript;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void TurretInfo (TurretBlueprint TurretBlueprint )
    {

        GameObject Turret = TurretBlueprint.prefab;
        TurretScript = Turret.GetComponent<Turret>();

        TurretName.text = TurretScript.TurretName;

        if(TurretScript.useLaser == true)
        {
            dmg.text = TurretScript.damageOverTime.ToString();
        }
        else
        {
            dmg.text = TurretScript.bulletPrefab.GetComponent<Bullet>().damage.ToString();
        }

        speed.text = TurretScript.fireRate.ToString();
        range.text = TurretScript.range.ToString();
        slow.text = TurretScript.slowAmount.ToString();
        AOE.text = TurretScript.bulletPrefab.GetComponent<Bullet>().explosionRadius.ToString();
    }

    public void SelectStandardTurret ()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
        TurretInfo(standardTurret);
    }
    public void SelectMissleLuncher ()
    {
        Debug.Log("MissleLuncher Turret Selected");
        buildManager.SelectTurretToBuild(missileLuncher);
        TurretInfo(missileLuncher);
    }
    public void SelectLaserBeamer ()
    {
        Debug.Log("LaserBeamer Turret Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
        TurretInfo(laserBeamer);
    }
    public void SelectMiniGun ()
    {
        Debug.Log("LaserBeamer Turret Selected");
        buildManager.SelectTurretToBuild(MiniGun);
        TurretInfo(MiniGun);
    }
    public void SelectSniper ()
    {
        Debug.Log("LaserBeamer Turret Selected");
        buildManager.SelectTurretToBuild(Sniper);
        TurretInfo(Sniper);
    }
}