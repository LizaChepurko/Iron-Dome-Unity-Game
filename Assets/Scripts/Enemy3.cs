using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public Transform target;
    public float speed = 7f;
    [SerializeField] private float lifetime = 10f;
    private bool isDestroyed = false;
    Animator animator;
    public GameObject explotion;

    public int maxHealth = 3;
    public int currentHealth;

    public HealthBar healthBar;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        transform.rotation = Quaternion.Euler(0, 0, -90);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Destroy(gameObject, lifetime);

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("enabled", !isDestroyed);
        if (!target)
        {
            GetTarget();    
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.right * speed;
    }

    private void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(explotion, transform.position, Quaternion.identity);
        }
        if (other.gameObject.CompareTag("Missile") && currentHealth > 0)
        {

            Destroy(other.gameObject);
            TakeDamage(1);
        }

        if (other.gameObject.CompareTag("hetzmissile") && currentHealth > 0)
        {

            Destroy(other.gameObject);
            TakeDamage(3);
        }

        if ((other.gameObject.CompareTag("Missile") || other.gameObject.CompareTag("hetzmissile")) && currentHealth <= 0)
        {
            Destroy(other.gameObject);
            Instantiate(explotion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            isDestroyed = true;

        }
    }
}
