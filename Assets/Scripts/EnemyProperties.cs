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
    private bool gotHit;
    [System.NonSerialized] public ScoreHandler scoreHandler;
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
        if (!isDead && !gotHit && !scoreHandler.gameOver) transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (scoreHandler.gameOver) GetComponent<Animator>().Play("Actions.Idle");
    }

    // On collison with a fruit obtains the projectile properties from that fruit
    // Then, destroys the fruit and applies the damage
    IEnumerator OnTriggerEnter(Collider collider)
    {
        if (!scoreHandler.gameOver && (collider.gameObject.tag.Contains("Fruit") || collider.gameObject.tag.Contains("Seed")))
        {
            projectileProperties = collider.gameObject.GetComponent<ProjectileProperties>();
            health -= projectileProperties.damage;
            if (health <= 0) {
                health = 0;
                isDead = true;
                GetComponent<Animator>().Play("Actions.Die");
                Destroy(gameObject, 2);
            } else {
                gotHit = true;
                GetComponent<Animator>().Play("Actions.GetHit");
            }
            Destroy(collider.gameObject);
            healthIndicator.text = "Health: " + health;

            // Let the hit animation complete
            yield return new WaitForSeconds(1);
            gotHit = false;
        } 
    }
}

