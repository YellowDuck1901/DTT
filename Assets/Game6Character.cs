using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6Character : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    LoadWinLose wl;

    [SerializeField]
    CounterTime CounterTime;

    [SerializeField]
    AudioSource BG, Break, win, lose;

    [SerializeField]
    SelectLevel sl;
    bool isTriggerWin, isTriggerLose, finish;
    private void Start()
    {
        animator = GetComponent<Animator>();    
    }

    private void Update()
    {
        if (!CounterTime.getStatusCounter() && !isTriggerWin)
        {
            isTriggerWin = true;
            PlayerWin();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isTriggerLose)
        {
            isTriggerLose = true;
            animator.SetTrigger("Die");
            Break.Play();
        }
    }

    void PlayerLose()
    {
        if (!finish)
        {
            finish = true;
            lose.Play();
            BG.Stop();
            LoadWinLose.loadLose(wl);
            sl.openSceneWithColdDown();
        }
    }

    void PlayerWin()
    {
        if (!finish)
        {
            finish = true;
            win.Play();
            BG.Stop();
            LoadWinLose.loadWin(wl);
            sl.openSceneWithColdDown();
        }
    }
}
