using UnityEngine;

public class HealthEnnemy : MonoBehaviour
{
    public int maxHealth = 50; // Valeur de sant� maximale de l'ennemi
    public int currentHealth; // Valeur de sant� actuelle de l'ennemi

    private void Start()
    {
        currentHealth = maxHealth; // Initialiser la sant� actuelle � la valeur maximale
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Soustraire la quantit� de d�g�ts de la sant� actuelle de l'ennemi

        if (currentHealth <= 0)
        {
            Die(); // Appeler la fonction Die lorsque la sant� de l'ennemi atteint z�ro ou devient inf�rieure
        }
    }

    private void Die()
    {
        // Effectuer toutes les actions n�cessaires lorsque l'ennemi meurt
        // Par exemple, vous pouvez d�truire l'ennemi, jouer une animation de mort ou ajouter des points au score du joueur
        Destroy(gameObject);
    }
}
