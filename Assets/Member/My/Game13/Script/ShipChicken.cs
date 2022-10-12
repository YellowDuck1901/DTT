using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipChicken : MonoBehaviour
{
    //public GameObject explosion;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("da cham");
        if(collision.tag == "boom")
        {
            anim.SetBool("die", true);
            //Debug.Log("chet");
        }
        else if(collision.tag == "fruit")
        {
            Debug.Log("an duoc trai cay");
        }
        //GameObject e = Instantiate(explosion) as GameObject;
        //e.transform.position = transform.position;
        Destroy(collision.gameObject);
        collision.gameObject.SetActive(false);
    }
}
