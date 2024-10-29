using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settlement : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth;

    private Rigidbody2D rb;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("enemy1") && currentHealth > 0)
        {

            Destroy(other.gameObject);
            TakeDamage(1);
        }

        if (other.gameObject.CompareTag("enemy2") && currentHealth > 0)
        {

            Destroy(other.gameObject);
            TakeDamage(2);
        }

        if (other.gameObject.CompareTag("enemy3") && currentHealth > 0)
        {

            Destroy(other.gameObject);
            TakeDamage(3);
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
