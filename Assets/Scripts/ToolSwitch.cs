using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToolSwitch : MonoBehaviour
{
    public GameObject toolMenuObject, origin;
    private GameObject currentToolMenu;

    // Start is called before the first frame update
    void Start()
    {        
        toolMenuObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateMenu()
    {   
        Destroy(currentToolMenu);
        currentToolMenu = Instantiate(toolMenuObject, origin.transform.position, origin.transform.rotation);
        currentToolMenu.SetActive(true);
    }

    public void DeactivateMenu()
    {
        currentToolMenu.SetActive(false);
    }
}
