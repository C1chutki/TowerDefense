using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLuncher;
    public TurretBlueprint laserBeamer;
    Turret turret;

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
        dmg.text = "10";
        speed.text = "1";
        range.text = "15";
        slow.text = "0";
        AOE.text = "0";
    }
    public void SelectMissleLuncher ()
    {
        Debug.Log("MissleLuncher Turret Selected");
        buildManager.SelectTurretToBuild(missileLuncher);
    }
    public void SelectLaserBeamer ()
    {
        Debug.Log("LaserBeamer Turret Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}