using UnityEngine;

public class Item : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private SpriteRenderer spriteRenderer;
    public bool IsCarried { get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        IsCarried = false;
    }

    public void PickUp(Transform holder)
    {
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
        coll.enabled = false; // Désactiver le collider pour le faire traverser par le joueur
        spriteRenderer.enabled = false; // Désactiver le rendu visuel pour le faire disparaître du sol
        transform.SetParent(holder);
        transform.localPosition = Vector3.zero;
        IsCarried = true;
    }

    public void Drop()
    {
        rb.gravityScale = 1f;
        coll.enabled = true; // Réactiver le collider pour permettre les interactions physiques
        spriteRenderer.enabled = true; // Réactiver le rendu visuel pour le faire réapparaître sur le sol
        transform.SetParent(null);
        IsCarried = false;
    }
}
