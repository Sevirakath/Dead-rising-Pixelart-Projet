using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void TakeDamage(int damage)
    {
        // Handle enemy damage here
        Debug.Log("Enemy took " + damage + " damage.");
    }
}