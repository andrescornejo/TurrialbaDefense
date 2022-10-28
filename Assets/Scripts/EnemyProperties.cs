using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyProperties : MonoBehaviour
{
    public int health;
    public TMP_Text healthIndicator;
    private ProjectileProperties projectileProperties;
    public float speed;
    [System.NonSerialized] public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        healthIndicator.text = "Health: " + health;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead) transform.Translate(-Vector3.forward * Time.deltaTime * speed);
    }

    // On collison with a fruit obtains the projectile properties from that fruit
    // Then, destroys the fruit and applies the damage
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Contains("Fruit"))
        {
            projectileProperties = collider.gameObject.GetComponent<ProjectileProperties>();
            health -= projectileProperties.damage;
            if (health <= 0) {
                health = 0;
                isDead = true;
                GetComponent<Animator>().Play("Base Layer.die");
                Destroy(gameObject, 2);
            }
            Destroy(collider.gameObject);
            healthIndicator.text = "Health: " + health;
        } 
    }
}

