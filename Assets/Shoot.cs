using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint; // Mettre sur Unity là ou le projectile va spawn 
    [SerializeField] private GameObject bulletPrefab; // Mettre sur Unity l'objet qu'on va faire spawn(donc notre projectile)
    [SerializeField] private float speed = 5; // Vitesse du projectile

    private SpriteRenderer sr; //SpriteRenderer du GameObject  

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1")) // Si on appuie sur le bouton ("Fire1") 
        {
            shoot(); //on lance shoot()
        }
    }
    private void shoot()
    {
        
            if (sr.flipX == true) // On verifie si le SpriteRenderer de l'object qu'on a renseigner avant a flip sur x si oui: 
            {
                GameObject go = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation); //on spawn un projectile au shooting.position et tourne comme le transform.rotation 
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0); //On fais maintenant bouger l'object par rapport a la speed qu'on a mis avant 
            }
            else
            {
                GameObject go = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation); // Meme chose que l'autre
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0); //Meme chose mais va de l'autre sens
            }
        
    }
}
