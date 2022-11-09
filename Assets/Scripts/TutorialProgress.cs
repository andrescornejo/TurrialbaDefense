using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TutorialProgress : MonoBehaviour
{
    public TutorialHandler tutorialHandler;
    public RoundHandler roundHandler;
    public InventoryManager inventory;
    public bool isPrevious;
    private bool gameStarted;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (tutorialHandler.skipTutorial) return;
        if (collider.gameObject.tag.Contains("Fruit") || collider.gameObject.tag.Contains("Seed"))
        {
            if (!isPrevious){
                if (tutorialHandler.currentMessage < tutorialHandler.messages.Count - 1) {
                    tutorialHandler.currentMessage++;
                }
                if (tutorialHandler.currentMessage == tutorialHandler.messages.Count - 1 && !gameStarted) {
                    gameStarted = true;
                    inventory.ResetInventory();
                    StartCoroutine(roundHandler.StartRound());
                }
            } else {
                if (tutorialHandler.currentMessage > 0) {
                    tutorialHandler.currentMessage--;
                }
            }
        }
    }
}
