using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class BullBot : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
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
}
