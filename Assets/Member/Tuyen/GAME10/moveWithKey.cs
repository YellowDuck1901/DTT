using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWithKey : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool moveLeft;
    private bool moveRight;
    private bool moveUp;
    private bool moveDown;
    private float horizontalMove;
    private float verticalMove;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveLeft = false;
        moveRight = false;
        moveUp = false;
        moveDown = false;

    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ResetBtn();
            moveLeft = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            ResetBtn();
            moveDown = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            ResetBtn();
            moveUp = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            ResetBtn();
            moveRight = true;
        }
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
        }
        else if (moveRight)
        {
            horizontalMove = speed;
        }
        else if (moveUp)
        {
            verticalMove = speed;
        }
        else if (moveDown)
        {
            verticalMove = -speed;
        }

    }

    public void ResetBtn()
    {
        verticalMove = 0;
        horizontalMove = 0;
        moveLeft = false;
        moveRight = false;
        moveUp = false;
        moveDown = false;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, verticalMove);
        //rb.velocity = new Vector2(rb.velocity.x, verticalMove);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //        Debug.Log("win collider");
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"OnTriggerEnter2D called. other's tag was {collision.tag}.");
        if (collision.CompareTag("Goal"))
        {
            Debug.Log("win");

        }
    }


}
