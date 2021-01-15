using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        
        if (instance != null)
        {
            Debug.LogError("More then one BuildManager in scene!");
            return;
        }

        instance = this;
    }

    public GameObject standardTurretprefab;
    public GameObject MissleLuncherPrefab;

    public GameObject buildEffect;
   

    private TurretBlueprint turretToBuild;

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
 
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {

        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not Enough money to build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject BuildEffect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);

        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }


    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
