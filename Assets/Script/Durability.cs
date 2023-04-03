using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Durability : MonoBehaviour
{

    // only really put to public for inspector ease of use... use your favored accessibility type
    public float maxDurability = 100.0f;  // max durability
    public float curDurability;   // current durability

    void Start()
    {
        curDurability = maxDurability;  // start out brand new
    }

    public void HitSomething()
    {
        curDurability -= 5; // take 5 durability away

        if (curDurability <= 0)
        {
            Debug.Log(gameObject.name + " is broken!"); // just print for now
        }
    }

}