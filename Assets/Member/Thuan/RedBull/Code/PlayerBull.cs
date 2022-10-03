using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
public delegate float BullPower();

public class PlayerBull : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    [Range(1.1f, 5f)]
    public float powerSup;
    BullPower Pull;
    private float ford() => Random.Range(10f, 15f);
    private bool isPower = false;
    float offset = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Mouse0) | Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log(" click");
            isPower = true;
        }
        
    }
    private void FixedUpdate()
    {
        if (isPower)
        {
            m_Rigidbody.AddForce(Vector2.right * ford()* offset * powerSup * Time.fixedDeltaTime, ForceMode2D.Impulse);
            isPower = false;
        }
    }
}
