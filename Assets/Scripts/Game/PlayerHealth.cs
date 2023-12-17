using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 50; // Maximum health value
    private int currentHealth; // Current health value
    private GameManager gameManager;
    public AudioSource hurtAudio;
    public HealthBar healthBar;

    void Start()
    {
        gameManager = GameManager.Instance;

        if (gameManager != null)
        {
            // Access GameManager properties or methods
        }
        else
        {
            Debug.LogError("GameManager not found.");
        }

        currentHealth = maxHealth; // Set the initial health to the maximum health
        healthBar.SetMaxHealth(maxHealth);
    }

    // Method to apply damage to the player
    public void TakeDamage(int damageAmount)
    {
        hurtAudio.Play();

        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);

        // Check if the player has run out of health
        if (currentHealth <= 0)
        {
            Die();
        }

        Debug.Log(currentHealth);
    }

    // Method to handle player death
    void Die()
    {
        // Perform any actions you want when the player dies
        // For example: Play death animation, reset level, etc.
        Debug.Log("Player has died.");
        gameManager.GameOver();
    }
}
