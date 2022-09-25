using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMove : MonoBehaviour
{
    public float speed = 20f;
    private Vector3 target;
    public GameObject Parent;
    public bool isActive;
    public float x, y;
    public bool isHide;

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
        isActive = true;
        transform.parent.GetComponentInParent<PlayerScript>().isTouched = false;
        transform.parent.GetComponentInParent<PlayerScript>().HiddenObj();
    }

    public void DetachFromParent()
    {
        // Detaches the transform from its parent.
        transform.parent = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        isHide = true;
        if(transform.tag == "Left")
        {
            x = -1;
            y = 0;
        } else if(transform.tag == "Right")
        {
            x = 1;
            y = 0;
        } else if(transform.tag == "Up")
        {
            y = 1;
            x = 0;
        } else if(transform.tag == "Down")
        {
            x = 0;
            y = -1;
        } else
        {
            Debug.Log($"x = {x}, y = {y} ERROR");
        }
       isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!transform.parent.GetComponentInParent<PlayerScript>().isTouched && isActive == true)
        {
            transform.parent.position += new Vector3(x, y, 0) * speed * Time.deltaTime;
        } else
        {
            isActive = false;
            transform.parent.GetComponentInParent<PlayerScript>().ShowObj();
        }

        gameObject.GetComponent<Renderer>().enabled = isHide;
        Debug.Log($"isHide = {isHide} ");
    }

}
