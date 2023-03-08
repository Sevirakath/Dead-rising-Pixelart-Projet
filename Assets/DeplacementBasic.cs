using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementBasic : MonoBehaviour
{
    public float speed;

    float MovementX;
    float MovementY;

    Rigidbody2D Rb;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /* Ici, on utilise un get axis pour avoir la sensibilité 
        pour utiliser eventuellemnt une manette avec des joystic */
        
        MovementX = Input.GetAxisRaw("Horizontal");
        MovementY = Input.GetAxisRaw("Vertical");

        Rb.velocity = new Vector2(MovementX * speed * Time.deltaTime, MovementY * speed * Time.deltaTime);
    }
}
