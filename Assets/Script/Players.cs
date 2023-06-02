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

    // Picking up items
    public float pickUpRange = 1f;
    public LayerMask itemLayer;
    private List<Item> carriedItems = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animController = GetComponent<Animator>();
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUpItem();
        }
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

    void PickUpItem()
    {
        Collider2D[] itemColliders = Physics2D.OverlapCircleAll(transform.position, pickUpRange, itemLayer);
        foreach (Collider2D itemCollider in itemColliders)
        {
            Item item = itemCollider.GetComponent<Item>();
            if (item != null && !item.isCarried)
            {
                item.PickUp(transform);
                carriedItems.Add(item);
            }
        }
    }
}
