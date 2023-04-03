using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armerecupere : MonoBehaviour
{
    public GameObject myGun;
    public GameObject myGunOnGround;
    public GameObject otherObject;
    public GameObject newGun;

    // Use this for initialization
    void Start()
    {
     //   otherObject.GetComponent<PlayerShooting>().enabled = false;
        myGun.SetActive(false);
    }

    void OnTriggerEnter(Collider _collider)
    {
        if (_collider.gameObject.tag == "Player")
        {
            myGun.SetActive(true);
            myGunOnGround.SetActive(false);
        //    otherObject.GetComponent<PlayerShooting>().enabled = true;
        }





    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Instantiate(newGun, transform.position, transform.rotation);

            Drop();
        }
    }


    public void Drop()
    {
        myGun.SetActive(false);
    }

}