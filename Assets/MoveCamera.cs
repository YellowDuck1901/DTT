using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float rate;

    private bool isMove;
    Vector3 target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            transform.position = Vector3.Lerp(gameObject.transform.position, target, Time.deltaTime * rate);
        }
    }

    public void TurnOnMove(Vector3 targetPosition)
    {
        target = targetPosition;
        isMove= true;
    }

    public void TurnOffMove()
    {
        isMove = false; 
    }
}
