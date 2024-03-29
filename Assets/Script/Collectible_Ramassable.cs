using UnityEngine;

public class Collectible_Ramassable : MonoBehaviour
{
    private GameObject playerRef;

    private void Update()
    {
        PickUpPotion();
    }

    private void PickUpPotion()
    {
        if (playerRef && Input.GetKeyDown(KeyCode.E))
        {
            Health playerHealth = playerRef.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.pv += 10;
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerRef = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.gameObject == playerRef)
        {
            playerRef = null;
        }
    }
}
