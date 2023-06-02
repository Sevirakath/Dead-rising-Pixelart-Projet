using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1.5f; // Portée de l'attaque
    public int attackDamage = 1; // Dommages infligés à l'ennemi

    public Transform attackPoint; // Point d'attaque
    public LayerMask enemyLayer; // Layer contenant les ennemis

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("RightTrigger") > 0)
        {
            Attack();
        }
    }

    void Attack()
    {
        // Détecter les ennemis dans la portée d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        // Infliger des dommages aux ennemis touchés
        foreach (Collider2D enemy in hitEnemies)
        {
            // Vérifier si l'objet touché a un script d'ennemi
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(attackDamage);
            }
        }
    }

    // Dessine la portée d'attaque dans l'éditeur
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
