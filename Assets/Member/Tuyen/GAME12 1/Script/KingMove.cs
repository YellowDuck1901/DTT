using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMove : MonoBehaviour
{
    public float speed = 0.75f;
    double randomTime;
    public double time;
    public float stop = 3f;
    private Animator anim;
    private CamScript camScript;
    void Start()
    {
        anim = GetComponent<Animator>();
        randomTime = Random.Range(2f, 6f);
        time = 0;
        camScript = Camera.main.GetComponent<CamScript>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //}

    private void Update()
    {
        var remainTime = Time.realtimeSinceStartupAsDouble - time; // ~ 0
        //time += Time.realtimeSinceStartupAsDouble;
        if( (remainTime) >= randomTime) // 4
        {
            anim.SetBool("running", false);
            gameObject.transform.localScale = new Vector3(-1,1, 1); //flip player
                if(camScript.isMoving)
                {
                    Debug.Log("GAME OVER");
                }

            if (remainTime >= (randomTime + stop) ) //code l
            {
                randomTime = Random.Range(2f, 6f);
                time = Time.realtimeSinceStartupAsDouble;
            }
        } else //first time
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            anim.SetBool("running", true);
            gameObject.transform.localScale = new Vector3(1, 1, 1);


        }
    }
}
