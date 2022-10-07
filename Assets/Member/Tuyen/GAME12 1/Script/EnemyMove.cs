using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 1f;
    bool toggle;
    private Vector3 target;
    private Animator anim;
    private CamScript camScript;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        gameObject.transform.localScale = new Vector3(-1, 1, 1);
        anim = GetComponent<Animator>();
        camScript = Camera.main.GetComponent<CamScript>();  
        camScript.isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            toggle = !toggle;
            camScript.isMoving = toggle;
        }
        if (toggle)
        {
            target.x = transform.position.x + 1;
            target.y = transform.position.y;
            target.z = transform.position.z;
            anim.SetBool("running", true);
        }
        else
        {
            target.x = transform.position.x;
            target.y = transform.position.y;
            target.z = transform.position.z;
            anim.SetBool("running", false);
        }
        //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(destroyKing());
        }
    }
 
    IEnumerator destroyKing()
    {
        toggle = false;
        anim.SetBool("attack", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("attack", false);
        yield return new WaitForSeconds(1);
    }



}
