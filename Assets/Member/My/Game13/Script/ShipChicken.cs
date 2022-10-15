using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipChicken : MonoBehaviour
{
    //public GameObject explosion;
    private Animator anim;
    [SerializeField]
    private AudioSource addSoundEatBoom;

    [SerializeField]
    private AudioSource addSoundEatFruit;
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
            addSoundEatBoom.Play();
            //Debug.Log("chet");
        }
        else if(collision.tag == "fruit")
        {
            addSoundEatFruit.Play();
            Debug.Log("an duoc trai cay");
        }
        //GameObject e = Instantiate(explosion) as GameObject;
        //e.transform.position = transform.position;
        Destroy(collision.gameObject);
        collision.gameObject.SetActive(false);
    }
}
