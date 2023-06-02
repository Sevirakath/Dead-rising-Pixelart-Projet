using UnityEngine;

public class HealthEnnemy : MonoBehaviour
{
    public int maxHealth = 50; // Valeur de santé maximale de l'ennemi
    public int currentHealth; // Valeur de santé actuelle de l'ennemi

    private void Start()
    {
        currentHealth = maxHealth; // Initialiser la santé actuelle à la valeur maximale
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Soustraire la quantité de dégâts de la santé actuelle de l'ennemi

        if (currentHealth <= 0)
        {
            Die(); // Appeler la fonction Die lorsque la santé de l'ennemi atteint zéro ou devient inférieure
        }
    }

    private void Die()
    {
        // Effectuer toutes les actions nécessaires lorsque l'ennemi meurt
        // Par exemple, vous pouvez détruire l'ennemi, jouer une animation de mort ou ajouter des points au score du joueur
        Destroy(gameObject);
    }
}
