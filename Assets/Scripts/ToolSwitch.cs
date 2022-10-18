using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.InputSystem;

public class ToolSwitch : MonoBehaviour
{
    LinkedList<GameObject> toolList = new LinkedList<GameObject>();
    LinkedListNode<GameObject> currentTool;
    public Transform transformPivot;
    public GameObject weapon, scythe, hoe;

    // Instatiates, deactivates and adds all the tools to the list
    void Start()
    {        
        GameObject tempObject = Instantiate(weapon, transformPivot.position, transform.rotation);
        tempObject.SetActive(false);
        toolList.AddLast(tempObject);

        tempObject = Instantiate(scythe, transformPivot.position, transform.rotation);
        tempObject.SetActive(false);
        toolList.AddLast(tempObject);

        tempObject = Instantiate(hoe, transformPivot.position, transform.rotation);
        tempObject.SetActive(false);
        toolList.AddLast(tempObject);
         
        currentTool = toolList.First;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Deactivates the current tool and activates the next one in the list
    public void OnToolSwitch()
    {   
        currentTool.Value.SetActive(false);
        currentTool = currentTool.Next ?? toolList.First;
        currentTool.Value.SetActive(true);
        currentTool.Value.transform.position = new Vector3(transformPivot.position.x, transformPivot.position.y, transformPivot.position.z);
        currentTool.Value.transform.Translate(transformPivot.forward * 0.3f, Space.Self);
        currentTool.Value.transform.Translate(transformPivot.up * 1.5f, Space.Self);
    }
}
