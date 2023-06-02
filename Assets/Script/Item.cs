using UnityEngine;

public class Item : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool IsCarried { get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        IsCarried = false;
    }

    public void PickUp(Transform holder)
    {
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
        transform.SetParent(holder);
        transform.localPosition = Vector3.zero;
        IsCarried = true;
        gameObject.SetActive(false); // D�sactiver l'objet pour le faire dispara�tre du sol
    }

    public void Drop()
    {
        rb.gravityScale = 1f;
        transform.SetParent(null);
        IsCarried = false;
        gameObject.SetActive(true); // R�activer l'objet pour le faire r�appara�tre sur le sol
    }
}
