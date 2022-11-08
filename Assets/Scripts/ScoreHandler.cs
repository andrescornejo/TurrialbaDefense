using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public TMP_Text score;
    [System.NonSerialized] public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "";
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Contains("Enemy"))
        {
            gameOver = true;
            score.text = "Perdiste!";
        }
    }
}
