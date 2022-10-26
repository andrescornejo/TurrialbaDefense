using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class RadialMenuInputHandler : MonoBehaviour
{
    
    public InputActionProperty thumbstick;
    public GameObject selectionIndicator;
    // Holds the current state of the 4 available crops
    /*
        1 = tomato
        2 = corn
        3 = pumpkin
        4 = turnip
    */
    [System.NonSerialized] public int cropState = 1;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.gameObject.activeSelf)
        {
            return;
        }
        if (thumbstick.action.ReadValue<Vector2>().x <= 0.5 && 
            thumbstick.action.ReadValue<Vector2>().x >= -0.5 &&
            thumbstick.action.ReadValue<Vector2>().y >= 0.5)
        {
            // CORN position
            selectionIndicator.transform.localRotation = Quaternion.Euler(0, 0, 0);
            cropState = 1;
        }
        else if (thumbstick.action.ReadValue<Vector2>().x <= 0.5 && 
                 thumbstick.action.ReadValue<Vector2>().x >= -0.5 &&
                 thumbstick.action.ReadValue<Vector2>().y <= -0.5)
        {
            // TOMATO position
            selectionIndicator.transform.localRotation = Quaternion.Euler(0, 0, 180);
            cropState = 3;
        }
        else if (thumbstick.action.ReadValue<Vector2>().y <= 0.5 && 
                 thumbstick.action.ReadValue<Vector2>().y >= -0.5 &&
                 thumbstick.action.ReadValue<Vector2>().x >= 0.5)
        {
            // TURNIP position
            selectionIndicator.transform.localRotation = Quaternion.Euler(0, 0, 270);
            cropState = 4;
        }
        else if (thumbstick.action.ReadValue<Vector2>().y <= 0.5 && 
                 thumbstick.action.ReadValue<Vector2>().y >= -0.5 &&
                 thumbstick.action.ReadValue<Vector2>().x <= -0.5)
        {
            // PUMPKIN position
            selectionIndicator.transform.localRotation = Quaternion.Euler(0, 0, 90);
            cropState = 2;
        }
    }
}
