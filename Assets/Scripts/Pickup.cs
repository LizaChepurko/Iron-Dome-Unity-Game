using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private Inventory inventory;
    public GameObject effect;
    public GameObject itemButton;
    public float speed = 2f;
    [SerializeField] private float lifetime = 8f;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move the object to the right, scaled by the speed and frame time
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Missile") || other.gameObject.CompareTag("hetzmissile"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (!inventory.isFull[i])
                {
                    inventory.isFull[i] = true; // mark slot as full
                    GameObject newItemButton = Instantiate(itemButton, inventory.slots[i].transform, false);
                    break;
                }
            }
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}