using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using TMPro;

public class RadialMenuInputHandler : MonoBehaviour
{
    public InputActionProperty thumbstick;
    public GameObject selectionIndicator, cornObject, tomatoObject, turnipObject, pumpkinObject;
    [System.NonSerialized] public GameObject currentCrop;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        currentCrop = tomatoObject;
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
            currentCrop = tomatoObject;
        }
        else if (thumbstick.action.ReadValue<Vector2>().x <= 0.5 &&
                 thumbstick.action.ReadValue<Vector2>().x >= -0.5 &&
                 thumbstick.action.ReadValue<Vector2>().y <= -0.5)
        {
            // South position
            selectionIndicator.transform.localRotation = Quaternion.Euler(0, 0, 180);
            currentCrop = pumpkinObject;
        }
        else if (thumbstick.action.ReadValue<Vector2>().y <= 0.5 &&
                 thumbstick.action.ReadValue<Vector2>().y >= -0.5 &&
                 thumbstick.action.ReadValue<Vector2>().x >= 0.5)
        {
            // East position
            selectionIndicator.transform.localRotation = Quaternion.Euler(0, 0, 270);
            currentCrop = turnipObject;
        }
        else if (thumbstick.action.ReadValue<Vector2>().y <= 0.5 && 
                 thumbstick.action.ReadValue<Vector2>().y >= -0.5 &&
                 thumbstick.action.ReadValue<Vector2>().x <= -0.5)
        {
            // West position
            selectionIndicator.transform.localRotation = Quaternion.Euler(0, 0, 90);
            currentCrop = cornObject;
        }
    }
}
