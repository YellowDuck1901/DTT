using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBull : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float m_Thrust = 10f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            m_Rigidbody.AddForce(Vector3.right * (m_Thrust * 2.7f));
            m_Rigidbody.AddForce(Vector3.right);

    }
}
