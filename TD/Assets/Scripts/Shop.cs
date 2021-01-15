using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLuncher;
    public TurretBlueprint laserBeamer;
    

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret ()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
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
