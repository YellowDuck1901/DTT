using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Game1_MovingPosition : MonoBehaviour
{
    // Start is called before the first frame update
    bool left, right;
    public new Transform transform;
    public float speed;

    void Start()
    {
       transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            left = true;
        }
        else left = false;

        if (Input.GetKey(KeyCode.D))
        {
            right = true;
        }
        else right = false;

       
    }

    private void FixedUpdate()
    {
        if (left)
        {
            transform.position += Vector3.left * Time.fixedDeltaTime * speed;
        }


        if (right)
        {
            transform.position += Vector3.right * Time.fixedDeltaTime* speed;
        }
    }
}
