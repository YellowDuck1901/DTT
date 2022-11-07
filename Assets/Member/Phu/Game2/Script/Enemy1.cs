using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed;

    [SerializeField]
    private int heart;

    private Rigidbody2D rig;
    private Vector3 dir;

    [SerializeField]
    private Animator animator;
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
        dir = target.transform.position - transform.position;
        if (gameObject.name == "Slime") Manager_SFX.PlaySound_SFX(soundsGame.apperSlime);
        else if (gameObject.name == "Bat") Manager_SFX.PlaySound_SFX(soundsGame.apperBat);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rig.velocity = dir * speed * Time.fixedDeltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            heart--;
            rig.bodyType = RigidbodyType2D.Static;
            animator.SetTrigger("Hit");
        }
    }

    private void kill()
    {

        if (heart == 0)
        {
            Destroy(this.gameObject);
            Manager_SFX.PlaySound_SFX(soundsGame.deadEnemy);
     
        }
        else rig.bodyType = RigidbodyType2D.Dynamic;
    }

    



}
