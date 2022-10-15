using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log("colisition");
            Destroy(gameObject);
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
        }else rig.bodyType = RigidbodyType2D.Dynamic;
    }

    



}
