using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandData : MonoBehaviour
{

    public enum HandModelType { Left,Right}
    public HandModelType handModelType;
    public Transform root;
    public Animator animator;
    public Transform[] fingerBones;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
