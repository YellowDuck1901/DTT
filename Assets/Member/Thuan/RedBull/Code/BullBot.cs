using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullBot : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float m_Thrust = 20f;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(-1f, 0, 0);
        //m_Rigidbody.AddForce(transform. * m_Thrust);
        m_Rigidbody.AddForce(Vector3.left * m_Thrust);
    }
}
