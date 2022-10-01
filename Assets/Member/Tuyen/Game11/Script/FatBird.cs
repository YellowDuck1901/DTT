using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBird : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    public float speed = 3f;
    Vector2[] directionList;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        directionList = new Vector2[2] { 
            Vector2.left,
            Vector2.right
        };
    }

    // Update is called once per frame
    void Update()
    {
        var n = Random.Range(0, 2);
        var d = directionList[n];
        rb.AddForce(d * speed);
        //Debug.Log($"Debug direction : {(d== Vector2.left ? "left" : "right")}\n Num: {n}");
        if (Input.GetKey(KeyCode.Mouse0))
        {
            rb.AddForce(directionList[0] * speed * 0.5f);
            Debug.Log("LEFT");
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            rb.AddForce(directionList[1] * speed * 0.5f);
            Debug.Log("RIGHT");

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "trap")
        {
            Debug.Log("Lose");
        }
    }

}
