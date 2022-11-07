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

    [SerializeField]
    SelectLevel sl;
    bool isTriggerlose, isTriggerWin, finish;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
        Time.timeScale = 0;
        rg.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isTriggerlose)
        {
            isTriggerlose = true;
            animator.SetTrigger("hit");
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ??m s? l?n b?m chu?t vào màn hình
        {
            if(Time.timeScale == 0)
            {
                rg.bodyType = RigidbodyType2D.Dynamic;
                Time.timeScale = 1;
            }
            rg.velocity = new Vector3(0f, 0f, 0f);
            rg.AddForce(Vector2.up * speed * Time.fixedDeltaTime,ForceMode2D.Impulse); // hàm bay lên
        }

        if (!counterTime.getStatusCounter() && !isTriggerWin) 
        {
            isTriggerWin = true;
            win.Play();
            PlayerWin();
        }
    }

    void PlayerWin()
    {
        if (!finish)
        {
            finish = true;
            BG.Stop();

            LoadWinLose.loadWin(wl);
            sl.openSceneWithColdDown();
        }
    }

    void PlayerLose()
    {
        if (!finish)
        {
            finish = true;
            BG.Stop();
            lose.Play();
            LoadWinLose.loadLose(wl);
            sl.openSceneWithColdDown();
        }
    }
}
