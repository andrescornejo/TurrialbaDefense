using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropProperties : MonoBehaviour
{
    public GameObject growingCropPrefab, grownCropPrefab;
    public float growthTimeSeconds;
    public Vector3 maxSize;
    [System.NonSerialized] public Vector3 scaleChange;
    [System.NonSerialized] public float growthRate = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        // Calculates the amount needed to grow to max size in the given time
        scaleChange = new Vector3(
            maxSize.x / (growthTimeSeconds / growthRate),
            maxSize.y / (growthTimeSeconds / growthRate),
            maxSize.z / (growthTimeSeconds / growthRate));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
