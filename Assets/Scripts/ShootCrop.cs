using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCrop : MonoBehaviour
{

    private GameObject currentProjectile;
    public GameObject radialMenu;
    private RadialMenuInputHandler inputHandler;
    public GameObject ammo1;
	public GameObject ammo2;
	public GameObject ammo3;
	public GameObject ammo4;
    public GameObject origin;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        inputHandler = radialMenu.GetComponent<RadialMenuInputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (inputHandler.cropState)
        {
            case 1:
                currentProjectile = ammo1;
                break;
			case 2:
				currentProjectile = ammo2;
				break;
			case 3:
				currentProjectile = ammo3;
				break;
			case 4:
				currentProjectile = ammo4;
				break;
        }
    }

    public void shoot()
    {
        GameObject bullet = Instantiate(currentProjectile, origin.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(origin.transform.forward * force);
        Destroy(bullet, 4);
    }
}
