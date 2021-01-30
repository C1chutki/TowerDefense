using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("EnemyStats")]

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float StartHealth = 100;
    private float health;

    public int worth = 20;
    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image HealthBar;

    public bool isDead = false;


    void Start()
    {
        speed = startSpeed;
        health = StartHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        HealthBar.fillAmount = health / StartHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;
        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

   
}
