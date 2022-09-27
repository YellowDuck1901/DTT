using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class dichuyen : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    const int chay = 1;
    const int nhay = 2;
    const int tancong = 3;
    const int dungim = 0;
    const string Status = "Status";
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetInteger(Status, tancong);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            animator.SetInteger(Status, nhay);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetInteger(Status, chay);
        }
        else
        {
            animator.SetInteger(Status, dungim);
        }
    }
}
