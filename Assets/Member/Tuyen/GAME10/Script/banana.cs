using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banana : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
   [SerializeField] private AudioSource collectedSound;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collectedSound.Play();
            anim.SetBool("collected", true);
            Destroy(gameObject, 0.5f);
        }
    }
}
