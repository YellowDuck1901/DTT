using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBird : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    public float speed = 20f;
    Vector2[] directionList;
    Animator anim;
    private bool falling;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        directionList = new Vector2[2] { 
            Vector2.left,
            Vector2.right
        };
        anim = GetComponent<Animator>();
        falling = true;
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(falling)
        {
            rb.AddForce(directionList[Random.Range(0, 2)] * speed);
            //Debug.Log($"Debug direction : {(d== Vector2.left ? "left" : "right")}\n Num: {n}");
            if (Input.GetKey(KeyCode.Mouse0))
            {
                rb.AddForce(directionList[0] * speed * 1.25f);
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
                rb.AddForce(directionList[1] * speed * 1.25f);

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("fell", true);
            falling = false;
            anim.SetBool("death", true);
            Debug.Log("GAME OVER");
        }
        if(collision.gameObject.tag == "Goal")
        {
            falling = false;
            Debug.Log("Win");
        }
        if(collision.gameObject.tag == "trap")
        {
            falling = false;
            anim.SetBool("death", true);
            Debug.Log("Game Over");
        }
    }



}
