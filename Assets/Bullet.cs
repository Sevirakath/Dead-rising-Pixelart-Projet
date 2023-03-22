using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // speed of the bullet
    public Rigidbody2D rb; // reference to the Rigidbody2D component

    void Start()
    {
        // add velocity to the bullet
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // destroy the bullet when it hits an object with a collider
        Destroy(gameObject);
    }
}