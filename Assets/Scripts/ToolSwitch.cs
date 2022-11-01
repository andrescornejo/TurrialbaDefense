using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ToolSwitch : MonoBehaviour
{
    public GameObject toolMenu, origin;

    // Instatiates, deactivates and adds all the tools to the list
    void Start()
    {        

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Deactivates the current tool and activates the next one in the list
    public void UpdateMenuPosition()
    {   
        toolMenu.transform.position = origin.transform.position;
        toolMenu.transform.rotation = origin.transform.rotation;
        // foreach (Transform child in transform){
        //     child.gameObject.GetComponent<Rigidbody>().useGravity = false;
        // }
    }
}
