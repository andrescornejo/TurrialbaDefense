using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public int corn, tomato, turnip, pumpkin;
    public int cornSeeds, tomatoSeeds, turnipSeeds, pumpkinSeeds;
    public TMP_Text ammoText, seedText;
    public GameObject radialMenu;
    private RadialMenuInputHandler inputHandler;

    // Start is called before the first frame update
    void Start()
    {
        inputHandler = radialMenu.GetComponent<RadialMenuInputHandler>();
        DisplayCurrentAmmo(inputHandler.currentCrop);
        DisplayCurrentSeed(inputHandler.currentSeed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Contains("Fruit") || collider.gameObject.tag.Contains("Seed")){
            switch (collider.gameObject.tag)
            {
                case "Corn Fruit":
                    corn++;
                    break;
                case "Pumpkin Fruit":
                    pumpkin++;
                    break;
                case "Turnip Fruit":
                    turnip++;
                    break;
                case "Tomato Fruit":
                    tomato++;
                    break;
                case "Corn Seed":
                    cornSeeds++;
                    break;
                case "Pumpkin Seed":
                    pumpkinSeeds++;
                    break;
                case "Turnip Seed":
                    turnipSeeds++;
                    break;
                case "Tomato Seed":
                    tomatoSeeds++;
                    break;
            }
            Destroy(collider.gameObject);
            DisplayCurrentAmmo(inputHandler.currentCrop);
            DisplayCurrentSeed(inputHandler.currentSeed);
        }
    }

    public void DecreaseAmmo(GameObject currentCrop)
    {
        switch (currentCrop.tag)
        {
            case "Corn Fruit":
                corn--;
                break;
            case "Pumpkin Fruit":
                pumpkin--;
                break;
            case "Turnip Fruit":
                turnip--;
                break;
            case "Tomato Fruit":
                tomato--;
                break;
        }
        DisplayCurrentAmmo(currentCrop);
    }

    public void DecreaseSeeds(GameObject currentSeed)
    {
        switch (currentSeed.tag)
        {
            case "Corn Seed":
                cornSeeds--;
                break;
            case "Pumpkin Seed":
                pumpkinSeeds--;
                break;
            case "Turnip Seed":
                turnipSeeds--;
                break;
            case "Tomato Seed":
                tomatoSeeds--;
                break;
        }
        DisplayCurrentSeed(currentSeed);
    }

    public void DisplayCurrentAmmo(GameObject currentCrop)
    {
        string name = "Name";
        int amount = 0;
        switch (currentCrop.tag)
        {
            case "Corn Fruit":
                name = "Corn";
                amount = corn;
                break;
            case "Pumpkin Fruit":
                name = "Pumpkin";
                amount = pumpkin;
                break;
            case "Turnip Fruit":
                name = "Turnip";
                amount = turnip;
                break;
            case "Tomato Fruit":
                name = "Tomato";
                amount = tomato;
                break;
        }
        ammoText.text = name + ": "+ amount;
    }

    public void DisplayCurrentSeed(GameObject currentSeed)
    {
        int amount = 0;
        switch (currentSeed.tag)
        {
            case "Corn Seed":
                amount = cornSeeds;
                break;
            case "Pumpkin Seed":
                amount = pumpkinSeeds;
                break;
            case "Turnip Seed":
                amount = turnipSeeds;
                break;
            case "Tomato Seed":
                amount = tomatoSeeds;
                break;
        }
        seedText.text = "Seeds: " + amount;
    }
}
