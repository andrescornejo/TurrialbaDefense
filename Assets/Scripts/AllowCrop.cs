using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllowCrop : MonoBehaviour
{
    public GameObject nextSoilState  ;  

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // On collision with the hoe changes the game object to the next state of the soil
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Hoe"){
            GameObject cropSoil = Instantiate(nextSoilState, transform.position, transform.rotation);
            Destroy(gameObject, 0);
        } 
    }
}   