using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHelpMessages : MonoBehaviour
{


    public TMP_Text helpText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(displayMessages());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator displayMessages()
    {
        yield return new WaitForSeconds(20);
        helpText.text = "Go to the Crop Area\nPress the A button on right controller\nThis will bring the different weapons\nUse the Hoe to prepare floor\nScythe to hit the plant and get Crops ";
        yield return new WaitForSeconds(25);
        helpText.text = "Shoot the enemies and remember to look at all corners since those are the spawn points";
    }
}
