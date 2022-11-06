using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rg;
    public float speed;

    [SerializeField]
    LoadWinLose wl;

    [SerializeField]
    CounterTime counterTime;


    [SerializeField]
    AudioSource BG, collect, win, lose;

    bool isTriggerlose;
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
        if (Input.GetMouseButtonDown(0)) // ??m s? l?n b?m chu?t vào màn hình
        {
            rg.velocity = new Vector3(0f, 0f, 0f);
            rg.AddForce(Vector2.up * speed * Time.fixedDeltaTime,ForceMode2D.Impulse); // hàm bay lên
        }

        if (!counterTime.getStatusCounter() && !isTriggerlose) 
        {
            isTriggerlose = true;
            win.Play();
            PlayerWin();
        }
    }

    void PlayerWin()
    {
        BG.Stop();

        LoadWinLose.loadWin(wl);

    }

    void PlayerLose()
    {
        BG.Stop();
        lose.Play();
        LoadWinLose.loadLose(wl);

    }
}
