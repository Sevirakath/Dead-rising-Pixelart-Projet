using UnityEngine;

public class Item : MonoBehaviour
{
    private Collider2D coll;
    private SpriteRenderer spriteRenderer;
    public bool IsCarried { get; private set; }

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        IsCarried = false;
    }

    public void PickUp(Transform holder)
    {
        coll.enabled = false;
        spriteRenderer.enabled = false;
        transform.SetParent(holder);
        transform.localPosition = Vector3.zero;
        IsCarried = true;
    }

    public void Drop()
    {
        coll.enabled = true;
        spriteRenderer.enabled = true;
        transform.SetParent(null);
        IsCarried = false;
    }
}