using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    float horizontal_value;
    Vector2 ref_velocity = Vector2.zero;

    float jumpForce = 4f;

    [SerializeField] float moveSpeed_horizontal = 400.0f;
    bool is_jumping = false;
    bool can_jump = false;
    [Range(0, 1)] [SerializeField] float smooth_time = 0.1f;
    Animator animController;

    [SerializeField] Transform hand; // R�f�rence au transform de la main du joueur
    private GameObject heldItem; // R�f�rence � l'objet tenu

    bool isBatPlayer = false;
    Sprite originalSprite;
    [SerializeField] Sprite batSprite; // R�f�rence au sprite du joueur avec la batte

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animController = GetComponent<Animator>();

        originalSprite = sr.sprite; // Sauvegarder le sprite original du joueur
    }

    // Update is called once per frame
    void Update()
    {
        horizontal_value = Input.GetAxis("Horizontal");

        if (horizontal_value > 0)
            sr.flipX = false;
        else if (horizontal_value < 0)
            sr.flipX = true;

        if (Input.GetButtonDown("Jump") && can_jump)
        {
            is_jumping = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && heldItem == null)
        {
            PickUpItem();
        }

        // Contr�ler l'Animator pour l'�tat avec ou sans la batte
        animController.SetBool("HasBat", isBatPlayer);
    }

    void FixedUpdate()
    {
        if (is_jumping && can_jump)
        {
            is_jumping = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            can_jump = false;
        }

        Vector2 target_velocity = new Vector2(horizontal_value * moveSpeed_horizontal * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, smooth_time);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, 30);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            can_jump = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Item item = other.GetComponent<Item>();
            if (item != null && !item.IsCarried)
            {
                Debug.Log("Item picked up: " + item.name);
                heldItem = item.gameObject;
                item.PickUp(hand);
            }
        }

        if (other.CompareTag("Item"))
        {
            // Changer le sprite du joueur pour le sprite de la batte
            sr.sprite = batSprite;
            isBatPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            // R�tablir le sprite original du joueur
            sr.sprite = originalSprite;
            isBatPlayer = false;
        }
    }

    private void PickUpItem()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Item"))
            {
                Item item = collider.GetComponent<Item>();
                if (item != null && !item.IsCarried)
                {
                    Debug.Log("Item picked up: " + item.name);
                    heldItem = item.gameObject;
                    item.PickUp(hand);
                    break;
                }
            }
        }
    }
}
