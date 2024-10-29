using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed = 3f;
    [SerializeField] private float lifetime = 10f;
    private bool isDestroyed = false;
    Animator animator;
    public GameObject explotion;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, -90);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Destroy(gameObject, lifetime);

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("enabled", !isDestroyed);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Missile") || other.gameObject.CompareTag("hetzmissile"))
        {
            Destroy(other.gameObject);
            Instantiate(explotion,transform.position, Quaternion.identity);
            Destroy(gameObject);
            isDestroyed = true;

        }

    }
}
