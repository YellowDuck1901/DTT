using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 mousePos;
    public float moveSpeed = 5;
    public float minX = -8.15f;
    public float maxX = 8.20f;
    public float minY = -4.23f;
    public float maxY = -3.44f;

    void Start()
    {
        mousePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos = new Vector3(Mathf.Clamp(mousePos.x, minX, maxX), Mathf.Clamp(mousePos.y, minY, maxY));
        }
        transform.position = Vector3.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);
    }
}
