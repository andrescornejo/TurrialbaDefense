using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCrop : MonoBehaviour
{

    private GameObject currentProjectile;
    public GameObject radialMenu, fruitBasket;
    private RadialMenuInputHandler inputHandler;
    private DetectFruitAddition inventory;
    private bool hasAmmo;
    public GameObject cornObject, tomatoObject, turnipObject, pumpkinObject, origin;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        inventory = fruitBasket.GetComponent<DetectFruitAddition>();
        inputHandler = radialMenu.GetComponent<RadialMenuInputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (inputHandler.cropState)
        {
            case 1:
                currentProjectile = cornObject;
                hasAmmo = inventory.corn > 0;
                break;
			case 2:
				currentProjectile = tomatoObject;
                hasAmmo = inventory.tomato > 0;
                break;
			case 3:
				currentProjectile = turnipObject;
                hasAmmo = inventory.turnip > 0;
                break;
			case 4:
				currentProjectile = pumpkinObject;
                hasAmmo = inventory.pumpkin > 0;
                break;
        }
    }

    public void shoot()
    {
        if(hasAmmo){ 
            GameObject bullet = Instantiate(currentProjectile, origin.transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(origin.transform.forward * force);
         
                bullet.GetComponent<Rigidbody>().AddForce(origin.transform.up * 50.5f);
           

            inventory.DecreaseAmmo(currentProjectile.tag);
            Destroy(bullet, 3);
        }
    }
}
