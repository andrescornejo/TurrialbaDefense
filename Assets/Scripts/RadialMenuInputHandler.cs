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
        2 = pumpkin
        3 =
        4 =
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
            // North position
            selectionIndicator.transform.localRotation = Quaternion.Euler(0, 0, 0);
            cropState = 1;
        }
        else if (thumbstick.action.ReadValue<Vector2>().x <= 0.5 && 
                 thumbstick.action.ReadValue<Vector2>().x >= -0.5 &&
                 thumbstick.action.ReadValue<Vector2>().y <= -0.5)
        {
            // South position
            selectionIndicator.transform.localRotation = Quaternion.Euler(0, 0, 180);
            cropState = 3;
        }
        else if (thumbstick.action.ReadValue<Vector2>().y <= 0.5 && 
                 thumbstick.action.ReadValue<Vector2>().y >= -0.5 &&
                 thumbstick.action.ReadValue<Vector2>().x >= 0.5)
        {
            // West position
            selectionIndicator.transform.localRotation = Quaternion.Euler(0, 0, 270);
            cropState = 2;
        }
        else if (thumbstick.action.ReadValue<Vector2>().y <= 0.5 && 
                 thumbstick.action.ReadValue<Vector2>().y >= -0.5 &&
                 thumbstick.action.ReadValue<Vector2>().x <= -0.5)
        {
            // East position
            selectionIndicator.transform.localRotation = Quaternion.Euler(0, 0, 90);
            cropState = 4;
        }
    }
}
