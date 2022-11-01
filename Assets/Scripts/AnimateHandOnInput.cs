using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public XRDirectInteractor directInteractor;
    public Animator handAnimator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // This is the correct animation for pinch and grip
        // float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        // handAnimator.SetFloat("Trigger", triggerValue);
        // float gripValue = gripAnimationAction.action.ReadValue<float>();
        // handAnimator.SetFloat("Grip", gripValue);

        // Use grip animation on both pinch and grip and adjust for sticky grip
        if (directInteractor.interactablesSelected.Count != 0){
            handAnimator.SetFloat("Grip", 1);
        }
        else if (pinchAnimationAction.action.ReadValue<float>() != 0){
            float triggerValue = pinchAnimationAction.action.ReadValue<float>();
            handAnimator.SetFloat("Grip", triggerValue);
        }
        else if (gripAnimationAction.action.ReadValue<float>() != 0){
            float gripValue = gripAnimationAction.action.ReadValue<float>();
            handAnimator.SetFloat("Grip", gripValue);
        }
        else {
            handAnimator.SetFloat("Grip", 0);
        }
    }
}