using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveRight : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;
    bool toogle;
    public GameObject Parent;
    // Start is called before the first frame update
    void Start()
    {
    }


    public void SetParent(GameObject newParent)
    {
        //Makes the GameObject "newParent" the parent of the GameObject "player".
        Parent.transform.parent = newParent.transform;

        //Display the parent's name in the console.
        Debug.Log("Player's Parent: " + Parent.transform.parent.name);

        // Check if the new parent has a parent GameObject.
        if (newParent.transform.parent != null)
        {
            //Display the name of the grand parent of the player.
            Debug.Log("Player's Grand parent: " + Parent.transform.parent.parent.name);
            target = newParent.transform.parent.position;
        }
    }

    public void OnMouseDown()
    {
            target.x = transform.parent.position.x + 10;
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, target, speed * Time.deltaTime);
    }
    public void DetachFromParent()
    {
        // Detaches the transform from its parent.
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
       

    }
}
