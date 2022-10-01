using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private float speed = 10f;
    Vector2 mousePosition;
    private float x, y;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.transform.position;
        rb.transform.position = Vector2.MoveTowards(position, mousePosition, speed * Time.deltaTime);
    }
}
