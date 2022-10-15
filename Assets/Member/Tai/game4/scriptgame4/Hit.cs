using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("hit");

    }
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
    
