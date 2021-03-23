using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color HoverColor;
    public Color NotEnoughMoneyColor;
    private Color startColor;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    public Vector3 positionOffSet;
    public GameObject circleRangeNode;
    BuildManager buildManager;
    public Vector3 usun;
    

    private Renderer rend;

    void Start()
    {
        circleRangeNode.SetActive(true);
        circleRangeNode.GetComponent<SpriteRenderer>().color=new Color(255,255,255,0);
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

        if (turret != null)
        {
            //Debug.Log("Najechane w SelectNode");
            buildManager.SelectNode(this);
            
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());

    }


    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not Enough money to build that!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject BuildEffect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(BuildEffect, 5f);
        Debug.Log("Turret build!");
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.UpgradeCost)
        {
            Debug.Log("Not Enough money to Upgrade that!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.UpgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.UpgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject BuildEffect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(BuildEffect, 5f);
        isUpgraded = true;

        Debug.Log("Turret upgraded!"); 
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        GameObject SellEffect = (GameObject)Instantiate(buildManager.SellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(turret);
        turretBlueprint = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            //circleRangeNode.transform.localScale = new Vector3(turretBlueprint.turretRange, turretBlueprint.turretRange, 0f);
            //circleRangeNode.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            //this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            //this.gameObject.transform.GetChild(0).transform.localScale = new Vector3(turretBlueprint.turretRange, turretBlueprint.turretRange, 1f);
            //usun = this.gameObject.transform.GetChild(0).transform.localScale;
            //Debug.Log(turretBlueprint.turretRange);
            //circleRangeNode.SetActive(true);
            //Debug.Log("Najechane w Has money");
            rend.material.color = HoverColor;
        }
        else
        {
            rend.material.color = NotEnoughMoneyColor;
            //Debug.Log("Najechane w brak kasy");
        }
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
        circleRangeNode.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        //circleRangeNode.SetActive(false);
    }

}
