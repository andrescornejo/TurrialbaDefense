using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    //Variable for setting the enemy health
    public int health;

    // Variable that saves the damage taken from the last bullet
    private int damageTaken;

    // Variable for setting the script CropDamage
    private CropDamage bulletProperties;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Decreases the health if a bullet hit
    private void receiveDamage(int damage){

        this.health = this.health - damage;
        checkHealth();

    }


    // On collison with a bullet obtains the bullet properties
    // Then, applies the damage to the enemy's health
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
                bulletProperties = collider.gameObject.GetComponent<CropDamage>();
                Destroy(collider.gameObject, 1);

                // Getting the damage from the bullet that hit
                this.damageTaken = bulletProperties.getDamage();
                receiveDamage(damageTaken);
        } 
            
        return;
    }

    // Check if health is below 0 to destroy the damaged object
    private void checkHealth(){

        // If health is below 0 the object will be destroyed
        if(this.health <= 0){
            Destroy(this.GetComponent<Collider>().gameObject, 1);
        }
    }
}

