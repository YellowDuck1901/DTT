using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rg;
    public float speed;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("hit");

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ??m s? l?n b?m chu?t v�o m�n h�nh
        {
            rg.AddForce(Vector2.up * speed); // h�m bay l�n
        }
    }
    void GameOver()
    {
        Debug.Log("aaaaa");
        Time.timeScale = 0; // dung lai

    }


}
