using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrowCrop : MonoBehaviour
{
    private CropProperties cropProperties;
    private GameObject growingCrop, grownCrop;
    private bool seedGrew = false;
    public GameObject nextSoilState;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (grownCrop == null && seedGrew == true)
        {
            GameObject grassSoil = Instantiate(nextSoilState, transform.position, transform.rotation);
            Destroy(gameObject, 0);
        }
    }

    // On collison with a seed obtains the crop properties from that seed
    // Then, destroys the seed and creates a growing crop
    // After the specified time, destroys the growing crop and creates a grown crop
    IEnumerator OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Contains("Seed") && growingCrop == null && grownCrop == null)
        {
            cropProperties = collider.gameObject.GetComponent<CropProperties>();
            growingCrop = Instantiate(cropProperties.growingCropPrefab, transform.position, transform.rotation);
            Destroy(collider.gameObject);
            InvokeRepeating("IncreaseScale", 2, cropProperties.growthRate);
            yield return new WaitForSeconds(cropProperties.growthTimeSeconds);
            CancelInvoke("IncreaseScale");
            grownCrop = Instantiate(cropProperties.grownCropPrefab, transform.position, transform.rotation);
            Destroy(growingCrop);
            seedGrew = true;
        } 
    }

    // This function is called every "growthRate" seconds
    // Increases the scale of the growing crop object
    void IncreaseScale()
    {
        if (growingCrop != null)
        {
            growingCrop.transform.localScale += cropProperties.scaleChange;
        }   
    }
}   