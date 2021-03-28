using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [HideInInspector]
    private Transform target;
    [HideInInspector]
    private Enemy targetEnemy;

    [Header("General")]
    public float range = 15f;
    public float Speed;
    public float AttackSpeed;

    //firecountdown = 1f / 3 * Random.Rand(2, 4);


    [Header("Use Bullets")]
    public float fireRate = 1f;
    public float fireCountDown = 0f;
    public float fireCountDown2 = 0f;
    public float fireCountDown3 = 0f;
    public float fireCountDown4 = 0f;
    public float fireCountDown5 = 0f;
    public float fireCountDown6 = 0f;
    public GameObject bulletPrefab;

    [Header("Use Laser")]
    public bool useLaser = false;
    public int damageOverTime = 20;
    public float slowAmount = .2f;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public ParticleSystem impactEffect2;
    public Light impactLight;


    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    [Header("Tower Rotate")]
    public Transform partToRotate;
    public float turnSpeed = 6f;

    [Header("Choose Barrel")]
    public bool barrel1;
    public bool barrel2;
    public bool barrel3;
    public bool barrel4;
    public bool barrel6;

    [Header("FirePoint")]
    public Transform FirePoint;
    public Transform FirePoint2;
    public Transform FirePoint3;
    public Transform FirePoint4;
    public Transform FirePoint5;
    public Transform FirePoint6;





    Animator MiniGun;
    Animator MiniGunv2;
    //bool didFunction = false;



    private void Start()
    {
        MiniGun = GetComponent<Animator>();
        MiniGunv2 = GetComponent<Animator>();
        InvokeRepeating ("UpdateTarget", 0f, 0.001f);
    }

    public void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }else
        {
            target = null;
        }
    }


    private void Update()
    {
        if (target == null)
        {
            if (barrel4 == true) { MiniGun.SetBool("IsActive", false); }
            if (barrel6 == true) { MiniGunv2.SetBool("IsActivev2", false); }
            
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactEffect2.Stop();
                    impactLight.enabled = false;
                }
                    
            }
            return;
        }
        

        LockOnTarget();

        //Lasers
        if (useLaser)
        {
            Laser();
        }

        //Single barrel turret
        if (barrel1)
        {
            if (fireCountDown <= 0f)
            {
                ShootOne();
                fireCountDown = 1f / fireRate;
            }
            fireCountDown -= Time.deltaTime;
        }


        //Double barrel turret
        if (barrel2)
        {
            if (fireCountDown <= 0f)
            {
                ShootOne();
                fireCountDown = 1f / Random.Range(0.5f, 1);
            }
            
            fireCountDown -= Time.deltaTime;
            
            if (fireCountDown2 <= 0f)
            {
                ShootTwo();
                fireCountDown2 = 1f / Random.Range(0.5f, 1);
            }
            fireCountDown2 -= Time.deltaTime;
        }



        //Standard Upgraded
        if (barrel3)
        { 

            //if (fireCountDown <= 0)
            //{
            //    ShootOne();
            //}

            //if (fireCountDown <= 0f)
            //{
            //    ShootOne();
            //    fireCountDown = 1f / AttackSpeed;

            //    Debug.Log(fireCountDown);
            //    Debug.Log("Barrel1");

            //}
            //fireCountDown -= Time.deltaTime;

            if (fireCountDown <= 0f)
            {
                ShootThree();
                fireCountDown = 1f / AttackSpeed;
                Debug.Log(fireCountDown);
                Debug.Log("Barrel2");

            }
            fireCountDown -= Time.deltaTime;

            if (fireCountDown <= 0f)
            {
                ShootFour();
                fireCountDown = 1f / AttackSpeed;
                Debug.Log(fireCountDown);
                Debug.Log("Barrel3");
            }
            fireCountDown -= Time.deltaTime;
        }




        // Minigun

        if (barrel4)
        {

            if (fireCountDown <= 0f)
            {
                ShootOne();
                fireCountDown = 1f / Random.Range(6, 10);
            }
            fireCountDown -= Time.deltaTime;

            if (fireCountDown2 <= 0f)
            {
                ShootTwo();
                fireCountDown2 = 1f / Random.Range(6, 10);
            }
            fireCountDown2 -= Time.deltaTime;

            if (fireCountDown3 <= 0f)
            {
                ShootThree();
                fireCountDown3 = 1f / Random.Range(6, 10);
            }
            fireCountDown3 -= Time.deltaTime;

            if (fireCountDown4 <= 0f)
            {
                ShootFour();
                fireCountDown4 = 1f / Random.Range(6, 10);
            }
            fireCountDown4 -= Time.deltaTime;

        }



        //Minigun Upgraded Version
        if (barrel6)
        {
            if (fireCountDown <= 0f)
            {
                ShootOne();
                fireCountDown = 1f / Random.Range(6, 10);
            }
            fireCountDown -= Time.deltaTime;


            if (fireCountDown2 <= 0f)
            {
                ShootTwo();
                fireCountDown2 = 1f / Random.Range(6, 10);
            }
            fireCountDown2 -= Time.deltaTime;


            if (fireCountDown3 <= 0f)
            {
                ShootThree();
                fireCountDown3 = 1f / Random.Range(6, 10);
            }
            fireCountDown3 -= Time.deltaTime;


            if (fireCountDown4 <= 0f)
            {
                ShootFour();
                fireCountDown4 = 1f / Random.Range(6, 10);
            }
            fireCountDown4 -= Time.deltaTime;


            if (fireCountDown5 <= 0f)
            {
                ShootFive();
                fireCountDown5 = 1f / Random.Range(6, 10);
            }
            fireCountDown5 -= Time.deltaTime;


            if (fireCountDown6 <= 0f)
            {
                ShootSix();
                fireCountDown6 = 1f / Random.Range(6, 10);
            }
            fireCountDown6 -= Time.deltaTime;
        }
    }


    public void LockOnTarget()
    {
        if(barrel4 == true) {
            MiniGun.SetBool("IsActive", true);
        }
        if(barrel6 == true) {
            MiniGunv2.SetBool("IsActivev2", true);
        }

        //Target Look on and follow the enemy
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }

    // laser function
    void Laser()
    {
       targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactEffect2.Play();
            impactLight.enabled = true;
        }
            

        lineRenderer.SetPosition(0, FirePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = FirePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;

        impactEffect2.transform.position = FirePoint.position;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

        
    }

   
    // all the shoot function for different barrels
    void ShootOne()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }
    void ShootTwo()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, FirePoint2.position, FirePoint2.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }
    void ShootThree()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, FirePoint3.position, FirePoint3.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }
    void ShootFour()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, FirePoint3.position, FirePoint3.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    void ShootFive()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, FirePoint3.position, FirePoint3.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }
    
    void ShootSix()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, FirePoint3.position, FirePoint3.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}
