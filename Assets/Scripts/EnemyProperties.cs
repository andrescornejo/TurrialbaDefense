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
    public GameObject seedDropPrefab;
    public int seedDropMaxAmount, seedDropChance;
    private float dropDelay = 0.1f;
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

    // Each enemy has a chance to drop X amount of seeds
    // Each seed has a Y chance of being dropped
    IEnumerator DropSeeds()
    {
        Vector3[] angles = {transform.right, transform.forward, transform.right*-1, transform.forward*-1};
        LinkedList<Vector3> anglesList = new LinkedList<Vector3>(angles);
        LinkedListNode<Vector3> current = anglesList.First;

        for (int i = 0; i < seedDropMaxAmount; i++){
            int rand = UnityEngine.Random.Range(0, 100);
            if (rand <= seedDropChance){
                yield return new WaitForSeconds(dropDelay);
                GameObject drop = Instantiate(seedDropPrefab, transform.position, transform.rotation);

                // Position at a proper upper point
                drop.transform.Translate(0.0f, 1.2f, 0.0f);
                drop.SetActive(true);

                // Apply force to the object
                drop.GetComponent<Rigidbody>().AddForce(transform.up * 500);
                drop.GetComponent<Rigidbody>().AddForce(current.Value * 200);                

                current = current.Next ?? current.List.First;
            }
        }
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
                DropSeeds();
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

