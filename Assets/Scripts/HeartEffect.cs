using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartEffect : MonoBehaviour
{
    private Transform playerTransform;
    private Player playerScript;
    private int healthIncreaseAmount = 4; // Amount by which health will be increased
    private Inventory inventory;
    private int slotIndex;

    private void Start()
    {
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
            // Increase the player's current health, but do not exceed max health
           playerScript.currentHealth = Mathf.Min(playerScript.currentHealth + healthIncreaseAmount, playerScript.maxHealth);
           playerScript.healthBar.SetHealth(playerScript.currentHealth);
        
    }
}
