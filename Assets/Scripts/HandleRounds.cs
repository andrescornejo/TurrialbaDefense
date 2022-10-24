using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using TMPro;

public class HandleRounds : MonoBehaviour
{
    public GameObject group;
    public Transform corner1, corner2, corner3, corner4;
    public TMP_Text mText;
    List<int> roundTimesList ;
    List<Transform> spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        roundTimesList = new List<int> { 40, 30, 60, 10 };
        spawnPoints = new List<Transform> { corner1, corner2, corner3, corner4 };
        StartCoroutine(SendEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SendEnemies()
    {
        mText.text = "Round starts soon! Get Ready";
        yield return new WaitForSeconds(30);
        var random = new System.Random();
 
        int amountRounds = roundTimesList.Count;
        
        for (int i = 0; i < amountRounds; i++)
        {
            var secondsUntilNextRound = roundTimesList[i];
            var corner = spawnPoints[random.Next(4)];
            var m = Instantiate(group, corner.position, corner.rotation);
            m.SetActive(true);
            while (secondsUntilNextRound > 1)
            {
                mText.text = "Time until next round: " + secondsUntilNextRound.ToString() + "s";
                yield return new WaitForSeconds(1);
                secondsUntilNextRound -= 1;
            }
            mText.text = "Here they come! Be Ready...";
            yield return new WaitForSeconds(2);
        }

    }
}
