using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject Hetz3;
    public bool hasHetz;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 2f)]
    [SerializeField] private float fireRate = 0.5f;

    private Inventory inventory;

    private Rigidbody2D rb;
    private float mx;
    private float my;

    private float fireTimer;

    private Vector2 mousePos;

    public int maxHealth = 20;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        inventory = new Inventory();
        hasHetz = false;
    }

    // Update is called once per frame
    void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        transform.localRotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0) && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
        }
        else
        {
            fireTimer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx, my).normalized * speed;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void Shoot()
    {
        if (hasHetz)
        {
            Instantiate(Hetz3, firingPoint.position, firingPoint.rotation);
            hasHetz = false;
        }
        else
        {
            Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("enemy2") && currentHealth > 0)
        {

            Destroy(other.gameObject);
            TakeDamage(1);
        }

        if (other.gameObject.CompareTag("enemy3") && currentHealth > 0)
        {

            Destroy(other.gameObject);
            TakeDamage(3);
        }

        if (other.gameObject.CompareTag("katbam") && currentHealth > 0)
        {

            Destroy(other.gameObject);
            TakeDamage(4);
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
