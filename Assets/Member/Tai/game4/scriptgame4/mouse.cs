using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class mouse : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            Debug.Log("va cham");
        }
    }

    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    Vector3 mousePosition;
    float X;
    float Y = 0;
    float Z;
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition)
            + new Vector3(0f, 0f, 1f);
        X = mousePosition.x;
        Z = mousePosition.z;
        transform.position = new Vector3(X, Y, Z);
    }
   
}
