using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailScript : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;
    bool toggle;
    public Sprite Shell;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetMouseButtonDown(0))
        {
            toggle = !toggle;
        }   
     if(toggle)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Shell;
        } else
        {
            target.x = transform.position.x - 1;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

     transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
