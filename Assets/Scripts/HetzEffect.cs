using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HetzEffect : MonoBehaviour
{
    private Transform playerTransform;
    private Player playerScript;
    private int healthIncreaseAmount = 4; 
    private Inventory inventory;

    private void Start()
    {
        // Find the player and get the player script component
        GameObject PlayerObject = GameObject.FindGameObjectWithTag("Player");
        if (PlayerObject != null)
        {
            playerTransform = PlayerObject.transform;
            playerScript = PlayerObject.GetComponent<Player>();
        }
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void Use()
    {
            Destroy(gameObject);
            playerScript.hasHetz = true;
    }
}
