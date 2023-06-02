using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health value
    public int currentHealth; // Current health value

    public int pv; // Additional property for "pv"

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to the maximum value
        pv = 0; // Initialize "pv" property
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Subtract the damage amount from the current health

        if (currentHealth <= 0)
        {
            Die(); // Call the Die function when health reaches zero or becomes negative
        }
    }

    private void Die()
    {
        // Perform all necessary actions when the object dies
        // For example, you can destroy the object, play an animation, or trigger a game over event
        Destroy(gameObject);
    }
}