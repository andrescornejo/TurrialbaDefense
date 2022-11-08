using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ActivateTeleportRay : MonoBehaviour
{
    public TeleportationProvider provider;
    public GameObject teleportationRay;
    public GameObject grabRay;
    public InputActionProperty cancelAction;
    public InputActionProperty thumbstick;
    private XRRayInteractor rayInteractor;
    private bool teleportCanceled;

    // Start is called before the first frame update
    void Start()
    {
        teleportationRay.SetActive(false);
        cancelAction.action.performed += OnTeleportCancel;
        rayInteractor = teleportationRay.GetComponent<XRRayInteractor>();
        teleportCanceled = false;
    }

    // Update is called once per frame
    void Update()
    {   
        // The ray is off
        if (!teleportationRay.activeSelf)
        {
            if (thumbstick.action.ReadValue<Vector2>().x <= 0.5 && 
                thumbstick.action.ReadValue<Vector2>().x >= -0.5 &&
                thumbstick.action.ReadValue<Vector2>().y >= 0.95)
            {
                if (!teleportCanceled)
                {
                    teleportationRay.SetActive(true);
                    //grabRay.SetActive(false);
                }
            } 
            else
            {
                teleportCanceled = false;
            }
        }

        // The ray is on
        else
        {
            if (thumbstick.action.ReadValue<Vector2>().x > 0.5 || 
                thumbstick.action.ReadValue<Vector2>().x < -0.5 ||
                thumbstick.action.ReadValue<Vector2>().y < 0)
            {
                teleportationRay.SetActive(false);
                //grabRay.SetActive(true);
                return;
            }

            if (thumbstick.action.ReadValue<Vector2>() != Vector2.zero) 
                return;

            // The ray didnt hit a valid target
            if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit) || !rayInteractor.hasHover)
            {
                teleportationRay.SetActive(false);
                //grabRay.SetActive(true);
                return;
            }   

            TeleportRequest request = new TeleportRequest()
            {
                destinationPosition = hit.point
            };

            provider.QueueTeleportRequest(request);
            teleportationRay.SetActive(false);
            //grabRay.SetActive(true);
        }
    }

    void OnTeleportCancel(InputAction.CallbackContext context)
    {
        teleportationRay.SetActive(false);
        //grabRay.SetActive(true);
        teleportCanceled = true;
    }
}
