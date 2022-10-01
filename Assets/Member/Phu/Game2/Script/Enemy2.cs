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


    private Rigidbody2D rig;
    private Vector3 dir;
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
        if(!isEverlasting)
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
            if (!isAlreadyEverlasting)
            {
                isEverlasting = true;
                StartCoroutine(Everlating());
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Everlating()
    {
        rig.bodyType = RigidbodyType2D.Static;
        //////////animation here
        yield return new WaitForSeconds(everlastingSecond);
        rig.bodyType = RigidbodyType2D.Dynamic;


        isEverlasting = false;
        isAlreadyEverlasting = true;
    }



}
