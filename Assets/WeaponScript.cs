using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour

{
    //in weapon script

    public Durability myDurability; // assuming your durability class is called Durability

    void Start()
    {
        if (!myDurability)
        {
            myDurability = gameObject.GetComponent<Durability>(); // if durability script not added in inspector... try to grab it on start
        }

        //Not sure of your weapon script set up so using "Attack" as a generic function
        void Attack()
        {
            // you usual code
            // if you detect a hit and try to apply damage.. call durability hit
            myDurability.HitSomething();
        }

    }

}