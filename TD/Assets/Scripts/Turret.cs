using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    [HideInInspector]
    private Enemy targetEnemy;

    [Header("General")]
    public float range = 15f;
    public string TurretName;

    [Header("Use Bullets")]
    public float fireRate = 1f;
    public GameObject bulletPrefab;

    [Header("FireCountDown")]
    private float fireCountDown = 0f;
    private float fireCountDown2 = 0f;
    private float fireCountDown3 = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public int damageOverTime = 20;
    public float slowAmount = .2f;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public ParticleSystem ImpactBarrelEffect;
    public ParticleSystem GlowEffect;
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
                                      
    [Header("ShootEffect")]           
    public ParticleSystem ShootEffect;
    public ParticleSystem ShootEffect2;
    public ParticleSystem ShootEffect3;
    public ParticleSystem ShootEffect4;
    public ParticleSystem ShootEffect5;
    public ParticleSystem ShootEffect6;

    [Header("Animations")]
    Animator MiniGun;
    Animator MiniGunv2;
    //Animator BarrelAnimation;

    private void Start()
    {
        ShootEffect.Stop();
        MiniGun = GetComponent<Animator>();
        MiniGunv2 = GetComponent<Animator>();
        //BarrelAnimation = GetComponent<Animator>();
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
                    ImpactBarrelEffect.Stop();
                    GlowEffect.Stop();
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
                //BarrelAnimation.SetBool("SetActive", true);
                ShootEffect.Play();
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

                ShootEffect.Play();
                ShootOne();
                fireCountDown = 1f / fireRate;
            }
            
            fireCountDown -= Time.deltaTime;
            
            if (fireCountDown <= 0f)
            {
                ShootEffect2.Play();
                ShootTwo();
                fireCountDown = 1f / fireRate;
            }
            fireCountDown -= Time.deltaTime;
        }

        //Standard Upgraded
        if (barrel3)
        {
            if (fireCountDown <= 0f)
            {
                ShootEffect.Play();
                ShootOne();
                fireCountDown = 1f / fireRate;
                Debug.Log(fireCountDown);
                Debug.Log("Barrel1");

            }
            fireCountDown -= Time.deltaTime;

            if (fireCountDown <= 0f)
            {
                ShootEffect.Play();
                ShootTwo();
                fireCountDown = 1f / fireRate;
                Debug.Log(fireCountDown2);
                Debug.Log("Barrel2");

            }
            fireCountDown -= Time.deltaTime;

            if (fireCountDown <= 0f)
            {
                ShootEffect.Play();
                ShootThree();
                fireCountDown = 1f / fireRate;
                Debug.Log(fireCountDown3);
                Debug.Log("Barrel3");
            }
            fireCountDown -= Time.deltaTime;
        }

        // Minigun
        if (barrel4)
        {

            if (fireCountDown <= 0f)
            {
                ShootEffect.Play();
                ShootOne();
                fireCountDown = 1f / fireRate;

                Debug.Log(fireCountDown);
                Debug.Log("Barrel1");

            }
            fireCountDown -= Time.deltaTime;

            if (fireCountDown <= 0f)
            {
                ShootEffect2.Play();
                ShootTwo();
                fireCountDown = 1f / fireRate;
                Debug.Log(fireCountDown);
                Debug.Log("Barrel2");

            }
            fireCountDown -= Time.deltaTime;

            if (fireCountDown <= 0f)
            {
                ShootEffect3.Play();
                ShootThree();
                fireCountDown = 1f / fireRate;
                Debug.Log(fireCountDown);
                Debug.Log("Barrel3");
            }
            fireCountDown -= Time.deltaTime;
            

            if (fireCountDown <= 0f)
            {
                ShootEffect4.Play();
                ShootFour();
                fireCountDown = 1f / fireRate;
                Debug.Log(fireCountDown);
                Debug.Log("Barrel4");
            }
            fireCountDown -= Time.deltaTime;

        }

        //Minigun Upgraded Version
        if (barrel6)
        {
            if (fireCountDown <= 0f)
            {
                ShootEffect.Play();
                ShootOne();
                fireCountDown = 1f / fireRate;

                Debug.Log(fireCountDown);
                Debug.Log("Barrel1");

            }
            fireCountDown -= Time.deltaTime;

            if (fireCountDown <= 0f)
            {
                ShootEffect2.Play();
                ShootTwo();
                fireCountDown = 1f / fireRate;
                Debug.Log(fireCountDown);
                Debug.Log("Barrel2");

            }
            fireCountDown -= Time.deltaTime;

            if (fireCountDown <= 0f)
            {
                ShootEffect3.Play();
                ShootThree();
                fireCountDown = 1f / fireRate;
                Debug.Log(fireCountDown);
                Debug.Log("Barrel3");
            }
            fireCountDown -= Time.deltaTime;


            if (fireCountDown <= 0f)
            {
                ShootEffect4.Play();
                ShootFour();
                fireCountDown = 1f / fireRate;
                Debug.Log(fireCountDown);
                Debug.Log("Barrel4");
            }
            fireCountDown -= Time.deltaTime;

            if (fireCountDown <= 0f)
            {
                ShootEffect5.Play();
                ShootFive();
                fireCountDown = 1f / fireRate;
                Debug.Log(fireCountDown);
                Debug.Log("Barrel5");
            }
            fireCountDown -= Time.deltaTime;

            if (fireCountDown <= 0f)
            {
                ShootEffect6.Play();
                ShootSix();
                fireCountDown = 1f / fireRate;
                Debug.Log(fireCountDown);
                Debug.Log("Barrel6");
            }
            fireCountDown -= Time.deltaTime;
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
            ImpactBarrelEffect.Play();
            GlowEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, FirePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = FirePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;
        GlowEffect.transform.position = target.position + dir.normalized;
        impactLight.transform.position = target.position + dir.normalized;

        ImpactBarrelEffect.transform.position = FirePoint.position;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    // all the shoot function for different barrels
    public void ShootOne()
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
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, FirePoint4.position, FirePoint4.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }
    void ShootFive()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, FirePoint5.position, FirePoint5.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }
    void ShootSix()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, FirePoint6.position, FirePoint6.rotation);
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
