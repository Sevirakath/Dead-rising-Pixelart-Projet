using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAdeType4 : MonoBehaviour
{
    float speeda = 5f;
    float distancea = 2f;
    private bool movingRight = true;
    public Transform groundDetection;
    public Transform target;
    public float speedb = 5f;
    float distancemax = 10;

    bool atckType1 = true;

    void function1()
    {
        transform.Translate(Vector2.right * speeda * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distancea);
        if (!groundInfo.collider)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    void function2()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speedb * Time.deltaTime);
        if (transform.position.y == 3)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < distancemax)
        {
            atckType1 = false;
        }
        else
        {
            atckType1 = true;
            if (atckType1)
            {
                function1();
            }
            else
            {
                function2();
            }
        }
    }
}
