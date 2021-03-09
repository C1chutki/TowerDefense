using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]
    public float range = 15f;
    public GameObject drawRange;

    [Header("Use Bullets")]
    public float fireRate = 1f;
    public float fireRate2 = 1f;
    private float fireCountDown = 0f;
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

    public Transform partToRotate;
    public float turnSpeed = 6f;

    public bool barrel1;
    public bool barrel2;
    public bool barrel3;
    public bool barrel4;
    public bool barrel6;

    public Transform FirePoint;
    public Transform FirePoint2;
    public Transform FirePoint3;
    public Transform FirePoint4;
    public Transform FirePoint5;
    public Transform FirePoint6;


    //Animator anim;
    bool didFunction = false;



    private void Start()
    {
        //anim = GetComponent<Animator>();
        InvokeRepeating ("UpdateTarget", 0f, 0.001f);               
    }

    void UpdateTarget ()
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
            //anim.SetBool("IsActive", false);
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

        if (useLaser)
        {
            Laser();
        }
        if (barrel1)
        {
            if (fireCountDown <= 0f)
            {
                Shoot();
                fireCountDown = 1f / fireRate;


            }
            fireCountDown -= Time.deltaTime;
        }
        if (barrel2)
        {
            if (fireCountDown <= 0f)
            {
                RocketShoot();
                fireCountDown = 1f / fireRate;


            }
            fireCountDown -= Time.deltaTime;
        }
        if (barrel3)
        {
            if (fireCountDown <= 0f)
            {
                StandardUpgradedShoot();
                fireCountDown = 1f / fireRate;


            }
            fireCountDown -= Time.deltaTime;
        }
        if (barrel4)
        {
            if (fireCountDown <= 0f)
            {
                MinigunShoot();
                fireCountDown = 1f / fireRate;
            }
            fireCountDown -= Time.deltaTime;

        }
        if (barrel6)
        {
            if (fireCountDown <= 0f)
            {
                MinigunShoot2();
                fireCountDown = 1f / fireRate;


            }
            fireCountDown -= Time.deltaTime;
        }
    }
    void LockOnTarget()
    {
        //anim.SetBool("IsActive", true);
        // Target Look on and follow the enemy
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }

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

    void Shoot ()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);

    }

    void StandardUpgradedShoot ()
    {
        GameObject bulletGO2 = (GameObject)Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet2 = bulletGO2.GetComponent<Bullet>();

        GameObject bulletGO3 = (GameObject)Instantiate(bulletPrefab, FirePoint2.position, FirePoint2.rotation);
        Bullet bullet3 = bulletGO3.GetComponent<Bullet>();

        GameObject bulletGO4 = (GameObject)Instantiate(bulletPrefab, FirePoint3.position, FirePoint3.rotation);
        Bullet bullet4 = bulletGO4.GetComponent<Bullet>();


        if (bullet2 != null)
            bullet2.Seek(target);
        if (bullet3 != null)
            bullet3.Seek(target);
        if (bullet4 != null)
            bullet4.Seek(target);
    }
    
    void RocketShoot ()
    {
        GameObject bulletGO2 = (GameObject)Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet2 = bulletGO2.GetComponent<Bullet>();

        GameObject bulletGO3 = (GameObject)Instantiate(bulletPrefab, FirePoint2.position, FirePoint2.rotation);
        Bullet bullet3 = bulletGO3.GetComponent<Bullet>();


        if (bullet2 != null)
            bullet2.Seek(target);
        if (bullet3 != null)
            bullet3.Seek(target);
    }

    void MinigunShoot()
    {
        GameObject bulletGO2 = (GameObject)Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet2 = bulletGO2.GetComponent<Bullet>();

        GameObject bulletGO3 = (GameObject)Instantiate(bulletPrefab, FirePoint2.position, FirePoint2.rotation);
        Bullet bullet3 = bulletGO3.GetComponent<Bullet>();

        GameObject bulletGO4 = (GameObject)Instantiate(bulletPrefab, FirePoint3.position, FirePoint3.rotation);
        Bullet bullet4 = bulletGO4.GetComponent<Bullet>();

        GameObject bulletGO5 = (GameObject)Instantiate(bulletPrefab, FirePoint4.position, FirePoint4.rotation);
        Bullet bullet5 = bulletGO5.GetComponent<Bullet>();


        if (bullet2 != null)
            bullet2.Seek(target);
        if (bullet3 != null)
            bullet3.Seek(target);
        if (bullet4 != null)
            bullet4.Seek(target);
        if (bullet5 != null)
            bullet5.Seek(target);
    }
    void MinigunShoot2()
    {
        GameObject bulletGO1 = (GameObject)Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet1 = bulletGO1.GetComponent<Bullet>();

        GameObject bulletGO2 = (GameObject)Instantiate(bulletPrefab, FirePoint2.position, FirePoint2.rotation);
        Bullet bullet2 = bulletGO2.GetComponent<Bullet>();

        GameObject bulletGO3 = (GameObject)Instantiate(bulletPrefab, FirePoint3.position, FirePoint3.rotation);
        Bullet bullet3 = bulletGO3.GetComponent<Bullet>();

        GameObject bulletGO4 = (GameObject)Instantiate(bulletPrefab, FirePoint4.position, FirePoint4.rotation);
        Bullet bullet4 = bulletGO4.GetComponent<Bullet>();
        
        GameObject bulletGO5 = (GameObject)Instantiate(bulletPrefab, FirePoint3.position, FirePoint3.rotation);
        Bullet bullet5 = bulletGO5.GetComponent<Bullet>();

        GameObject bulletGO6 = (GameObject)Instantiate(bulletPrefab, FirePoint4.position, FirePoint4.rotation);
        Bullet bullet6 = bulletGO6.GetComponent<Bullet>();


        if (bullet1 != null)
            bullet1.Seek(target);
        if (bullet2 != null)
            bullet2.Seek(target);
        if (bullet3 != null)
            bullet3.Seek(target);
        if (bullet4 != null)
            bullet4.Seek(target);
        if (bullet5 != null)
            bullet5.Seek(target);
        if (bullet6 != null)
            bullet6.Seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}
