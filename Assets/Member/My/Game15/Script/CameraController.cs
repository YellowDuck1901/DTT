using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cam;

    private bool atEdge;
    private bool moving;
    private string dir;
    private bool isRunning = false;
    private float x = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        atEdge = false;
        moving = false;
        dir = "Top";
    }

    // Update is called once per frame
    void Update()
    {
        if (!atEdge)
        {
            if (moving)
            {
                Move();
            }
        }
    }

    void Move()
    {
        if(dir == "Top")
        {
            cam.Translate(new Vector3( 0, Time.deltaTime * x, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "Top" && isRunning == false)
        {
            isRunning = true;
            moving = true;
            dir = "Top";
        }else if(other.tag == "Boundary")
        {
            atEdge = true;
        }        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Top")
        {
            moving = false;
            dir = "Top";
        }
        else if (other.tag == "Boundary")
        {
            atEdge = false;
        }

    }
}
