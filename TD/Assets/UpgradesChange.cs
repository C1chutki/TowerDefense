using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesChange : MonoBehaviour
{
    [Header("Simple Turret")]
    public GameObject SimpleBullet;
    public GameObject SimpleTower;
    public float SimpleBulletF;
    public float SimpleRange;
    public float SimpleSpeed;

    [Header("Rocket Turret")]
    public GameObject RocketBullet;
    public GameObject RocketTower;
    public float RocketBulletF;
    public float RocketRange;
    public float RocketAOE;



    // Start is called before the first frame update
    void Start()
    {
        SimpleTurretUpdate();
        RocketTurretUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SimpleTurretUpdate()
    {
        SimpleBulletF = PlayerPrefs.GetFloat("simplebulletdmg");
        SimpleRange = PlayerPrefs.GetFloat("simplerange");
        SimpleSpeed = PlayerPrefs.GetFloat("simplespeed");

        if (SimpleBulletF == 0)
        {
            SimpleBulletF = 1;
            PlayerPrefs.SetFloat("simplebulletdmg", SimpleBulletF);
        }

        if (SimpleRange == 0)
        {
            SimpleRange = 10;
            PlayerPrefs.SetFloat("simplerange", SimpleRange);
        }

        if (SimpleSpeed == 0)
        {
            SimpleSpeed = 1;
            PlayerPrefs.SetFloat("simplespeed", SimpleSpeed);
        }


        SimpleBullet.GetComponent<Bullet>().damage = SimpleBulletF;
        SimpleTower.GetComponent<Turret>().range = SimpleRange;
        SimpleTower.GetComponent<Turret>().fireRate = SimpleSpeed;
    }

    public void RocketTurretUpdate()
    {
        RocketBulletF = PlayerPrefs.GetFloat("Rocketbulletdmg");
        RocketRange = PlayerPrefs.GetFloat("Rocketrange");
        RocketAOE = PlayerPrefs.GetFloat("RocketAOE");

        if (RocketBulletF == 0)
        {
            RocketBulletF = 1;
            PlayerPrefs.SetFloat("simplebulletdmg", RocketBulletF);
        }

        if (RocketRange == 0)
        {
            RocketRange = 10;
            PlayerPrefs.SetFloat("Rocketrange", RocketRange);
        }

        if (RocketAOE == 0)
        {
            RocketAOE = 1;
            PlayerPrefs.SetFloat("RocketAOE", RocketAOE);
        }


        RocketBullet.GetComponent<Bullet>().damage = SimpleBulletF;
        RocketTower.GetComponent<Turret>().range = SimpleRange;
        RocketBullet.GetComponent<Bullet>().explosionRadius = RocketAOE;
    }
}
