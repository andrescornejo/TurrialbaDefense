using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateGrabRay : MonoBehaviour
{
    public GameObject leftGrabRay, rightGrabRay, leftTeleportRay, rightTeleportRay;

    public XRDirectInteractor leftDirectInteractor;
    public XRDirectInteractor rightDirectInteractor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftGrabRay.SetActive(leftDirectInteractor.interactablesSelected.Count == 0 && !leftTeleportRay.activeSelf);
        rightGrabRay.SetActive(rightDirectInteractor.interactablesSelected.Count == 0 && !rightTeleportRay.activeSelf);
    }
}
