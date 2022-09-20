using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
        public float speed = 5f;
        private Vector3 target;
        bool toogle;
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            toogle = !toogle;

        }
        if (toogle)
        {
            target.x = transform.position.x + 1;
            target.y = transform.position.y;
            target.z = transform.position.z;
        }
        else
        {
            target.x = transform.position.x - 1;
            target.y = transform.position.y;
            target.z = transform.position.z;
        }
        //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }
}