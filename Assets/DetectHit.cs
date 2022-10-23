using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  
public class DetectHit : MonoBehaviour
{
    float health = 200;
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
        switch (collision.gameObject.tag)
        {
            case "Corn Fruit":
                health -= 20;
                break;
            case "Pumpkin Fruit":
                health -= 50;
                break;
            case "Turnip Fruit":
                health -= 30;
                break;
            case "Tomato Fruit":
                health -= 40;
                break;
            default:
                return;
        }
  
        if (health < 1) {

            GetComponent<Animator>().Play("Base Layer.die");
            Destroy(gameObject, 2);
        }
        mText.text = "Health: "+health.ToString();
    }

   
  

}