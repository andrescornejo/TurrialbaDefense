using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectFruitAddition : MonoBehaviour
{
    public int corn, tomato, turnip, pumpkin;
    public TMP_Text mText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.tag.Contains("Fruit")) return;
        switch (collision.gameObject.tag)
        {
            case "Corn Fruit":
                corn++;
                DisplayCurrentAmmo("Corn", corn);
                break;
            case "Pumpkin Fruit":
                pumpkin++;
                DisplayCurrentAmmo("Pumpkin", pumpkin);
                break;
            case "Turnip Fruit":
                turnip++;
                DisplayCurrentAmmo("Turnip", turnip);
                break;
            case "Tomato Fruit":
                tomato++;
                DisplayCurrentAmmo("Tomato", tomato);
                break;
            default:
                break;
        }
        Destroy(collision.gameObject);
    }
    public void DecreaseAmmo(string ammoUsed)
    {
        switch (ammoUsed)
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
            default:
                break;
        }
    }

    IEnumerator DisplayCurrentAmmo(string ammoUpdated, int newAmount)
    {
        mText.text =  ammoUpdated + ": "+newAmount;
        yield return new WaitForSeconds(2);
        mText.text = "";
    }
}
