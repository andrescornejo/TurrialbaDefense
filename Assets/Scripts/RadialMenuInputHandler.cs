using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class RadialMenuInputHandler : MonoBehaviour
{
    
    public InputActionProperty thumbstick;
    public GameObject selectionIndicator;

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
            selectionIndicator.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (thumbstick.action.ReadValue<Vector2>().x <= 0.5 && 
                 thumbstick.action.ReadValue<Vector2>().x >= -0.5 &&
                 thumbstick.action.ReadValue<Vector2>().y <= -0.5)
        {
            selectionIndicator.transform.localRotation = Quaternion.Euler(0, 0, 180);
        }
        else if (thumbstick.action.ReadValue<Vector2>().y <= 0.5 && 
                 thumbstick.action.ReadValue<Vector2>().y >= -0.5 &&
                 thumbstick.action.ReadValue<Vector2>().x >= 0.5)
        {
            selectionIndicator.transform.localRotation = Quaternion.Euler(0, 0, 270);
        }
        else if (thumbstick.action.ReadValue<Vector2>().y <= 0.5 && 
                 thumbstick.action.ReadValue<Vector2>().y >= -0.5 &&
                 thumbstick.action.ReadValue<Vector2>().x <= -0.5)
        {
            selectionIndicator.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
    }
}
