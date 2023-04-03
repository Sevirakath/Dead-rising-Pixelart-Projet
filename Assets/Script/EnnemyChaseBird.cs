using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyChaseBird : MonoBehaviour
{
    
    public Transform target;
    public float speed = 5f;
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (true)
        {
            transform.position = new Vector3(transform.position.x, -3.47f, transform.position.z);
        }
    }
}
