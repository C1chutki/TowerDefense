using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        turretToBuild = standardTurretprefab;
    }

    private GameObject turretToBuild;
    
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
