using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public int corn, tomato, turnip, pumpkin;
    public TMP_Text ammoText;
    public GameObject radialMenu;
    private RadialMenuInputHandler inputHandler;

    // Start is called before the first frame update
    void Start()
    {
        inputHandler = radialMenu.GetComponent<RadialMenuInputHandler>();
        DisplayCurrentAmmo(inputHandler.currentCrop);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.tag.Contains("Fruit")) return;
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
        }
        Destroy(collider.gameObject);
        DisplayCurrentAmmo(inputHandler.currentCrop);
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

    public void DisplayCurrentAmmo(GameObject currentCrop)
    {
        string name = "Tomato";
        int amount = tomato;
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
}
