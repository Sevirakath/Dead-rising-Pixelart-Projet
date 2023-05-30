using UnityEngine;

public class CollideWithPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponentInChildren<Health>();
            if (playerHealth != null)
            {
                playerHealth.pv += 10;
            }

            Destroy(gameObject);
        }
    }
}