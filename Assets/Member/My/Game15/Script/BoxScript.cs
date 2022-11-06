using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    private Vector3 a, b;
    private bool active = false;

    [SerializeField]
    private float duration, speed;

    private float time, rate;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            time = rate * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, b, speed * Time.deltaTime); ;
            //rate = 1 / duration;
            //time = rate * Time.deltaTime;
            //transform.position = Vector3.Lerp(a, b, time);
        }
    }

    IEnumerator setMovingPosition()
    {
        
        
        while (true)
        {
            time = rate * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, b, speed*Time.deltaTime); ;
            yield return 0;
        }
    }  

    public void Moving(Vector3 vta, Vector3 vtb)
    {
        a = vta;
        b = vtb;
        active = true;
        //transform.position = vta;
        //rate = 1 / duration;
        //StartCoroutine(setMovingPosition()); 
    }

    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        active = false;
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }
}
