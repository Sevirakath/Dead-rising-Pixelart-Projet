using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testlightFlicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
 
        [SerializeField] float firstVariable;
        [SerializeField] float secondVariable;
        [SerializeField] float secondsBetweenFlickers;


    private void start ()

    {
        myLight = Getcomponent<Light2D>();
        StartCoroutine(LightFlicker());
    }
    IEnumerator LightFlicker()
    {
        yield return new WaitForseconds(secondsBetweenFlickers);
        myLight.pointLightOuterRadius = Random.Range(firstVariable, secondVariable);
        StartCoroutine(LightFlicker));
    }
}

