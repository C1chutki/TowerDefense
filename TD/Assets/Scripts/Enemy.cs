using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    [Header("EnemyStats")]

    public float startSpeed = 10f;
    
    [HideInInspector]
    public float speed;    

    public float StartHealth = 100;
    public float health;
    public float healthRegen = 0;

    public int worth = 20;
    public GameObject deathEffect;
    public GameObject pfDamagePopup;

    [Header("Unity Stuff")]
    public Image HealthBar;
    private Clicking click;

    public bool isDead = false;

    void Start()
    {
        speed = startSpeed;
        health = StartHealth;
        InvokeRepeating("Regenerate", 0.0f, 1.0f);
        click = FindObjectOfType<Clicking>();
        
    }

    void Regenerate()
    {
        if (health < StartHealth)
            health += healthRegen;
    }
    private void OnMouseDown()
    {
        Debug.Log("Clickdown!");
        GameObject temp = Instantiate(pfDamagePopup, transform.position, Quaternion.identity);
        temp.GetComponent<TextMeshPro>().text = click.clickpwr.ToString();

        health -= click.clickpwr;


        HealthBar.fillAmount = health / StartHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
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

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }
}
