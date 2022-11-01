using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootCrop : MonoBehaviour
{

    private GameObject currentProjectile;
    public GameObject radialMenu, inventory;
    private RadialMenuInputHandler inputHandler;
    private InventoryManager inventoryManager;
    public GameObject origin;
    public float force;
    public XRDirectInteractor leftDirectInteractor;
    public XRDirectInteractor rightDirectInteractor;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = inventory.GetComponent<InventoryManager>();
        inputHandler = radialMenu.GetComponent<RadialMenuInputHandler>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Check the inventory for available ammo
    private bool ammoAvailable()
    {   
        bool hasAmmo = false;
        switch (inputHandler.currentCrop.tag)
        {
            case "Corn Fruit":
                hasAmmo = inventoryManager.corn > 0;
                break;
			case "Tomato Fruit":
                hasAmmo = inventoryManager.tomato > 0;
                break;
			case "Turnip Fruit":
                hasAmmo = inventoryManager.turnip > 0;
                break;
			case "Pumpkin Fruit":
                hasAmmo = inventoryManager.pumpkin > 0;
                break;
        }
        return hasAmmo;
    }

    // Add a force to a fruit and destroy it after 3 seconds
    public void shoot()
    {   
        if (ammoAvailable() && rightDirectInteractor.interactablesSelected.Count == 0){ 
            GameObject bullet = Instantiate(inputHandler.currentCrop, origin.transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(origin.transform.forward * force);
            bullet.GetComponent<Rigidbody>().AddForce(origin.transform.up * 50.5f);
            inventoryManager.DecreaseAmmo(inputHandler.currentCrop);
            Destroy(bullet, 3);
        }
    }
}
