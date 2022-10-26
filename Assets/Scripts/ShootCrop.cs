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
                if (inventory.corn > 0)
                {
                    hasAmmo = true;
                    inventory.DecreaseAmmo(currentProjectile.tag);
                }
                else
                {
                    hasAmmo = false;
                }
                break;
			case 2:
				currentProjectile = tomatoObject;
                if (inventory.tomato > 0)
                {
                    hasAmmo = true;
                    inventory.DecreaseAmmo(currentProjectile.tag);
                }
                else
                {
                    hasAmmo = false;
                }
                break;
			case 3:
				currentProjectile = turnipObject;
                if (inventory.turnip > 0)
                {
                    hasAmmo = true;
                    inventory.DecreaseAmmo(currentProjectile.tag);
                }
                else
                {
                    hasAmmo = false;
                }
                break;
			case 4:
				currentProjectile = pumpkinObject;
                if (inventory.pumpkin > 0)
                {
                    hasAmmo = true; 
                    inventory.DecreaseAmmo(currentProjectile.tag);
                }
                else
                {
                    hasAmmo = false;
                }   

                break;
        }
    }

    public void shoot()
    {
        if(hasAmmo){ 
            GameObject bullet = Instantiate(currentProjectile, origin.transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(origin.transform.forward * force);
            Destroy(bullet, 4);
            
        }
        
    }
}
