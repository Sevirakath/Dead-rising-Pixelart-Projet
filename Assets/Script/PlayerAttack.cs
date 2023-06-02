using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1.5f; // Port�e de l'attaque
    public int attackDamage = 1; // Dommages inflig�s � l'ennemi

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
        // D�tecter les ennemis dans la port�e d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        // Infliger des dommages aux ennemis touch�s
        foreach (Collider2D enemy in hitEnemies)
        {
            // V�rifier si l'objet touch� a un script d'ennemi
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(attackDamage);
            }
        }
    }

    // Dessine la port�e d'attaque dans l'�diteur
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
