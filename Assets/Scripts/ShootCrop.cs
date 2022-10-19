using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCrop : MonoBehaviour
{

    private GameObject current_projectile;
    public GameObject radialMenu;
    private RadialMenuInputHandler inputHandler;
    public GameObject ammo1;
	public GameObject ammo2;
	public GameObject ammo3;
	public GameObject ammo4;
    public GameObject shoot_point;
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
                current_projectile = ammo1;
                break;
			case 2:
				current_projectile = ammo2;
				break;
			case 3:
				current_projectile = ammo3;
				break;
			case 4:
				current_projectile = ammo4;
				break;
        }
    }

    public void shoot()
    {
        GameObject bullet = Instantiate(current_projectile, shoot_point.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(shoot_point.transform.forward * force);
        Destroy(bullet, 4);
    }
}
