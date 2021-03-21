using UnityEngine;
using System.Collections;

[System.Serializable]

public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;
    public int turretRange;


    public GameObject UpgradedPrefab;
    public int UpgradeCost;
    public int turretRange2;

    public int GetSellAmount()
    {
        return (int)(cost * .8);
    }
}
