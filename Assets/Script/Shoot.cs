using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float speed = 5;

    private SpriteRenderer sr;
    private bool canShoot = true; // Flag to control shooting

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Use the right trigger of the controller for firing
        if (Input.GetAxis("Fire1") > 0 && canShoot)
        {
            shoot();
            canShoot = false; // Disable shooting until trigger is released
        }

        // Enable shooting when the trigger is released
        if (Input.GetAxis("Fire1") == 0)
        {
            canShoot = true;
        }
    }

    private void shoot()
    {
        if (sr.flipX)
        {
            GameObject go = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            go.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        }
        else
        {
            GameObject go = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            go.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
    }
}

