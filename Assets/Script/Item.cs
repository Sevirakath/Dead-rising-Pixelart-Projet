using UnityEngine;

public class Item : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isCarried { get; private set; } // Change to public property

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isCarried = false;
    }

    public void PickUp(Transform holder)
    {
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
        transform.SetParent(holder);
        transform.localPosition = Vector3.zero;
        isCarried = true;
    }
}
