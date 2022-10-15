using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPush : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody2D;

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (MechanicGame3.pushCharacter(rigidbody2D))
        {
            animator.SetTrigger("Fly");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        transform.eulerAngles = new Vector3(180, 0, 0);
        animator.SetBool("Grounded", true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        animator.SetBool("Grounded", false);

    }
}
