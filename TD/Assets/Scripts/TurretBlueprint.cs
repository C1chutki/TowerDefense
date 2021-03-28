using UnityEngine;
using System.Collections;

[System.Serializable]

public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;




    public int turretRange;
    //public string TurretName;
    //public string TurretDamage;
    //public string TurretSpeed;
    //public string TurretRange;
    //public string TurretAOE;
    //public string TurretSlow;


    public GameObject UpgradedPrefab;
    public int UpgradeCost;





    public int turretRange2;
    //public string TurretNamev2;
    //public string TurretDamagev2;
    //public string TurretSpeedv2;
    //public string TurretRangev2;
    //public string TurretAOEv2;
    //public string TurretSlowv2;

    public int GetSellAmount()
    {
        return (int)(cost);
    }
}
