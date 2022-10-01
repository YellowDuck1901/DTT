using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamelonMove : MonoBehaviour
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

    public void PointerDownLeft()
    {
        ResetBtn();
        moveLeft = true;
    }

    public void PointerDownRight()
    {
        ResetBtn();

        moveRight = true;
    }

    public void PointerDownUp()
    {
        ResetBtn();

        moveUp = true;
    }

    public void PointerDownDown()
    {
        ResetBtn();

        moveDown = true;
    }

    // Update is called once per frame
    void Update()
    {
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
}
