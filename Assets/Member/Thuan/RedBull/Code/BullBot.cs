using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class BullBot : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    private Animator _animator;
    private float ford() => Random.Range(7f, 12f);

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        m_Rigidbody.AddForce(Vector2.left * ford() * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    //Play Hit animation 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var _animator = gameObject.GetComponent<Animator>();
            StartCoroutine(Wait());
            //animation play one time
        }

    }

    IEnumerator Wait()
    {
        _animator = gameObject.GetComponent<Animator>();
        //animation hit play one time
        _animator.Play("Hit", -1, 0.1f);
        yield return new WaitForSeconds(.1f);
        _animator.Play("Run");
    }
}
