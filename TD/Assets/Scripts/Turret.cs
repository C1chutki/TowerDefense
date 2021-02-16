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
    private float fireCountDown2 = 0f;
    public GameObject bulletPrefab;
    public GameObject bullet2Prefab;

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

    
    public Transform FirePoint;
    public Transform FirePoint2;
    public Transform FirePoint3;

    

    private void Start()
    {
        InvokeRepeating ("UpdateTarget", 0f, 0.2f);               
    }

    public void ShowRange()
    {
        drawRange.SetActive(true);
        Debug.Log("true");
    }
    public void HideRange()
    {
        drawRange.SetActive(false);
        Debug.Log("false");
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
            if(useLaser)
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
        else
        {
            if (fireCountDown <= 0f)
            {
                Shoot();
                fireCountDown = 1f / fireRate;
                
                
            }
            if (fireCountDown2 <= 0f)
            {
                ShootSmall();
                fireCountDown2 = 1f / fireRate2;
                
                
            }
            
            fireCountDown -= Time.deltaTime;
            fireCountDown2 -= Time.deltaTime;
        } 
    }
    void LockOnTarget()
    {
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

    void ShootSmall ()
    {
        GameObject bulletGO2 = (GameObject)Instantiate(bullet2Prefab, FirePoint2.position, FirePoint2.rotation);
        Bullet bullet2 = bulletGO2.GetComponent<Bullet>();

        GameObject bulletGO3 = (GameObject)Instantiate(bullet2Prefab, FirePoint3.position, FirePoint3.rotation);
        Bullet bullet3 = bulletGO3.GetComponent<Bullet>();


        if (bullet2 != null)
            bullet2.Seek(target);
        if (bullet3 != null)
            bullet3.Seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}
