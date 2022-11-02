using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropCrop : MonoBehaviour
{
    public GameObject seedDropPrefab, cropDropPrefab;
    public int seedDropAmount, cropDropAmount, hitpoints;
    private float spawnDelay = 0.1f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter(Collider collider){
        if (collider.gameObject.tag == "Scythe") hitpoints--;
        if (collider.gameObject.tag == "Scythe" && hitpoints == 0)
        {
            Vector3[] angles = {transform.right, transform.forward, transform.right*-1, transform.forward*-1};
            LinkedList<Vector3> anglesList = new LinkedList<Vector3>(angles);
            LinkedListNode<Vector3> current = anglesList.First;

           // Spawn the crops
            for(int counter=0; counter < cropDropAmount; counter++){
                yield return new WaitForSeconds(spawnDelay);
                GameObject drop = Instantiate(cropDropPrefab, transform.position, transform.rotation);

                // Position at a proper upper point
                drop.transform.Translate(0.0f, 1.2f, 0.0f);

                // Apply force to the object
                drop.GetComponent<Rigidbody>().AddForce(transform.up * 500);
                drop.GetComponent<Rigidbody>().AddForce(current.Value * 200);                

                current = current.Next ?? current.List.First;
            }

            // Spawn the seeds
            for(int counter=0; counter < seedDropAmount; counter++){
                yield return new WaitForSeconds(spawnDelay);
                GameObject drop = Instantiate(seedDropPrefab, transform.position, transform.rotation);

                // Position at a proper upper point
                drop.transform.Translate(0.0f, 1.2f, 0.0f);

                // Apply force to the object
                drop.GetComponent<Rigidbody>().AddForce(transform.up * 500);
                drop.GetComponent<Rigidbody>().AddForce(current.Value * 200);                

                current = current.Next ?? current.List.First;
            }

            Destroy(gameObject);
        }
    }
}   