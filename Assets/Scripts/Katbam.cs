using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katbam : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    [SerializeField] private float lifetime = 8f;
    public GameObject explotion;

    private Rigidbody2D rb;
    public float rotateSpeed = 0.005f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }
        Destroy(gameObject, lifetime);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg -
        90f;
        Quaternion q = Quaternion.Euler(new Vector3(0,0,angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(explotion, transform.position, Quaternion.identity);
        }
        if (other.gameObject.CompareTag("Missile") || other.gameObject.CompareTag("hetzmissile"))
        {
            Destroy(other.gameObject);
            Instantiate(explotion, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

    }
}
