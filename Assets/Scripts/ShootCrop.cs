using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCrop : MonoBehaviour
{

    public GameObject projectile;
    public Transform shoot_point;
    public float force, fireRate, nextFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Time.time >= nextFire){

            nextFire = Time.time + 1f / fireRate;
            shoot();
        }
        */
    }

    public void shoot(){
        
        GameObject bullet = Instantiate(projectile, shoot_point.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * force);
        Destroy(bullet, 4);
    }
}
