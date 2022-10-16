using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float everlastingSecond;

    private bool isAlreadyEverlasting = false;

    private bool isEverlasting = false;

    [SerializeField]
    private Animator animator;

    private Rigidbody2D rig;
    private Vector3 dir;
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
        dir = target.transform.position - transform.position;
        G3_Sound.PlaySound(soundsGame.apperGhoot);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(!isEverlasting)
        rig.velocity = dir * speed * Time.fixedDeltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            G3_Sound.PlaySound(soundsGame.loseG2);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            if (!isAlreadyEverlasting)
            {
                isEverlasting = true;
                StartCoroutine(Everlating());
            }
            else
            {
                rig.bodyType = RigidbodyType2D.Static;
                animator.SetBool("IsHit", true);
            }
        }
    }

    IEnumerator Everlating()
    {
        rig.bodyType = RigidbodyType2D.Static;
        animator.SetBool("IsEverLast", true);
        yield return new WaitForSeconds(everlastingSecond);
        animator.SetBool("IsEverLast", false);
        rig.bodyType = RigidbodyType2D.Dynamic;
        isEverlasting = false;
        isAlreadyEverlasting = true;
    }

    void kill()
    {
        G3_Sound.PlaySound(soundsGame.deadEnemy);
        Destroy(this.gameObject);
    }
}
