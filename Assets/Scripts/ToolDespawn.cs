using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToolDespawn : MonoBehaviour
{
    private bool wasGrabbed;

    // Start is called before the first frame update
    void Start()
    {
        wasGrabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<XRGrabInteractable>().interactorsSelecting.Count != 0){
            wasGrabbed = true;
        }
        if (wasGrabbed && this.gameObject.GetComponent<XRGrabInteractable>().interactorsSelecting.Count == 0){
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            Destroy(this.gameObject, 3);
        }
    }
}
