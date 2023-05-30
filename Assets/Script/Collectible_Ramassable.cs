using UnityEngine;

public class Collectible_Ramassable : MonoBehaviour
{
    public int healAmount = 10;
    public KeyCode collectKey = KeyCode.E;

    private bool canCollect = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canCollect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canCollect = false;
        }
    }

    private void Update()
    {
        if (canCollect && Input.GetKeyDown(collectKey))
        {
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
