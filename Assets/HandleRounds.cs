using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleRounds : MonoBehaviour
{
    public GameObject group;
    public Transform corner1, corner2, corner3, corner4;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SendEnemies(corner2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator SendEnemies(Transform corner)
    {
        var m = Instantiate(group, corner1.position, corner1.rotation);
        m.SetActive(true);
        yield return new WaitForSeconds(8);
        var n = Instantiate(group, corner2.position, corner2.rotation);
        n.SetActive(true);
    }
}
