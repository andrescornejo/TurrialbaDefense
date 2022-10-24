using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerNearby : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3.2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .03f);
        }

    }
}
