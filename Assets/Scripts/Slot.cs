using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {


    private Inventory inventory;
    public int index;

    private void Start()
    {
        
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0) {
            inventory.isFull[index] = false;
        }
    }

    public void SpawnItem() {

        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
    }

}