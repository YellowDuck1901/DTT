using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed;
    private Rigidbody2D rig;
    private Vector3 dir;
    private Animator anim;

    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
        dir = target.transform.position - transform.position;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rig.velocity = dir * speed * Time.fixedDeltaTime;
    }

        int count = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //Destroy(collision.gameObject);
            Debug.Log("da dung con oc");
        }
    }

    public void BeeHit()
    {
        anim.SetTrigger("Hit");
    }

}
