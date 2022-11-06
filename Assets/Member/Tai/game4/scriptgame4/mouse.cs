using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class mouse : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    LoadWinLose wl;

    [SerializeField]
    CounterTime counterTime;


    [SerializeField]
    AudioSource BG, collect, win, lose;

    bool isTriggerLose;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            collect.Play();
            animator.SetTrigger("hit");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    Vector3 mousePosition;
    float X;
    float Y = 0;
    float Z;
    void Update()
    {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition)
               + new Vector3(0f, 0f, 1f);

        if (mousePosition.x != transform.position.x)
        {
            if (mousePosition.x - transform.position.x > 0) spriteRenderer.flipX = false;
            else spriteRenderer.flipX = true;
        }
           

        if (mousePosition.x >= -8.6 && mousePosition.x <= 8.6)
        {
            if (mousePosition.x != transform.position.x) animator.SetBool("Roll", true);
            else animator.SetBool("Roll", false);

            X = mousePosition.x;
            Z = mousePosition.z;
            transform.position = new Vector3(X, Y, Z);
        }

        if (!counterTime.getStatusCounter() && !isTriggerLose) {
            PlayerWin();
            isTriggerLose = true;
        }
       
    }

    void PlayerWin()
    {
        win.Play();
        BG.Stop();
        LoadWinLose.loadWin(wl);

    }

    void PlayerLose()
    {
        lose.Play();
        BG.Stop();
        LoadWinLose.loadLose(wl);

    }
}
