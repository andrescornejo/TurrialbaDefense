using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private GameObject player;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .03f);
        }
    }
}
