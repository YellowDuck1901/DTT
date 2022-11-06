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

    bool isTriggerSound;
    private void Start()
    {
        animator = GetComponent<Animator>();    
    }

    private void Update()
    {
        if (!CounterTime.getStatusCounter() && !isTriggerSound)
        {
            isTriggerSound = true;
            PlayerWin();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            animator.SetTrigger("Die");
            Break.Play();
        }
    }

    void PlayerLose()
    {
        lose.Play();
        BG.Stop();
        LoadWinLose.loadLose(wl);
    }

    void PlayerWin()
    {
        win.Play();
        BG.Stop();
        LoadWinLose.loadWin(wl);
    }
}
