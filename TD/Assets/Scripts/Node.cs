using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color HoverColor;
    public Color NotEnoughMoneyColor;
    private Color startColor;

    [Header("Optional")]
    public GameObject turret;

    public Vector3 positionOffSet;
    BuildManager buildManager;
    

    private Renderer rend;

    void Start()
    {
        
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffSet;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;


        if (turret != null)
        {
            Debug.Log("Nie mo¿esz tego zrobiæ!");
            return;
        }

        buildManager.BuildTurretOn(this);

    }


    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = HoverColor;
        } else
        {
            rend.material.color = NotEnoughMoneyColor;
        }
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
