using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy
    private int currentHealth; // Current health of the enemy

    void Start()
    {
        currentHealth = maxHealth; // Set the initial health to the maximum health when the enemy is spawned
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Decrease the current health by the damage amount

        // Check if the enemy is still alive
        if (currentHealth <= 0)
        {
            Die(); 
        }
    }
    void Die()
    {
        // Perform any death-related actions here, such as playing an animation, spawning particles, etc.
        Destroy(gameObject); // Destroy the enemy GameObject when it dies
    }
}
