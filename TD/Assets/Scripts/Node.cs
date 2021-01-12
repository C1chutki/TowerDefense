using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color HoverColor;
    private Color startColor;

    private GameObject turret;

    public Vector3 positionOffSet;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Nie mo¿esz tego zrobiæ!");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffSet, transform.rotation);


    }


    void OnMouseEnter()
    {
        rend.material.color = HoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
