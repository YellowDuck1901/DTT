using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicGame3 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float force;

    [SerializeField]
    int numberRoundToPush;

    float rotationLevel = 0;
    float zLastFrame = 0 , zInFrame;
    int totalRound;
    bool isIncrease;
    Rigidbody2D rigidbody2D;
    void Start()
    {
         rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        zInFrame = transform.eulerAngles.z;
        isIncreateRotation();
        stateRotation();
        zLastFrame = zInFrame;

        if(rotationLevel == 4)
        {
            Debug.Log("1 vong");
            totalRound++;
            rotationLevel = 0;
        }


    }

    private void FixedUpdate()
    {
        if(totalRound >= numberRoundToPush)
        {
            Debug.Log("push");
           totalRound -= numberRoundToPush;
            pushUp();
        }
    }


    void  stateRotation()
    {
        var rotation = transform.eulerAngles.z;
        if (zInFrame >= 0 && zInFrame <= 90 && rotationLevel == 0 && isIncrease)
        {
            rotationLevel = 1;
            //Debug.Log(rotationLevel);

        }

        else if (zInFrame >= 0 && zInFrame <= 90 && rotationLevel == 1 && !isIncrease)
        {
            rotationLevel = 2;
            //Debug.Log(rotationLevel);

        }


        else if (zInFrame >= 270 && zInFrame <= 360 && rotationLevel == 2 && !isIncrease)
        {
            rotationLevel = 3;
            //Debug.Log(rotationLevel);
        }

        else if (zInFrame >= 270 && zInFrame <= 360 && rotationLevel == 3 && isIncrease)
        {
            rotationLevel = 4;
            //Debug.Log(rotationLevel);
            //G1_Mechanic.ClearConsole();
        }

    }

    void isIncreateRotation()
    {
        if (zInFrame > zLastFrame)
        {
            isIncrease = true;
        }
        else isIncrease = false;
    }

    void pushUp()
    {
        rigidbody2D.velocity = new Vector2(0f,0f);
        rigidbody2D.AddForce(Vector2.up * force * Time.fixedDeltaTime,ForceMode2D.Impulse);
    }
}
