using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMove : MonoBehaviour
{
    public float speed = 0.75f;
    double randomTime;
    public double time;
    public float stop;
    private Animator anim;
    [SerializeField]
    private Animator CharacterAnim;

    private CamScript camScript;
    [SerializeField] private AudioSource kingDeathSound;
    [SerializeField] private AudioSource kingWinningSound;
    [SerializeField] private AudioSource BG;
    [SerializeField] private AudioSource BGL;


    [SerializeField] LoadWinLose wl;
    bool isTriggerWin, isTriggerLose, finish;
    void Start()
    {
        anim = GetComponent<Animator>();
        randomTime = Random.Range(2f, 6f);
        time = 0;
        camScript = Camera.main.GetComponent<CamScript>();
        stop = randomStopTime();

    }

    // Update is called once per frame
    //void Update()
    //{
    //}

    private void Update()
    {
        var remainTime = Time.realtimeSinceStartupAsDouble - time; // ~ 0
        //time += Time.realtimeSinceStartupAsDouble;
        if ((remainTime) >= randomTime) // 4
        {
            anim.SetBool("running", false);
            gameObject.transform.localScale = new Vector3(-1, 1, 1); //flip player
            if (camScript.isMoving && !isTriggerLose)
            {
                isTriggerLose = true;
                BGL.Play();
                CharacterAnim.SetTrigger("Die");
            }

            if (remainTime >= (randomTime + stop)) //code l
            {
                stop = randomStopTime();
                randomTime = Random.Range(2f, 6f);
                time = Time.realtimeSinceStartupAsDouble;
            }
        }
        else //first time
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            anim.SetBool("running", true);
            gameObject.transform.localScale = new Vector3(1, 1, 1);


        }
    }

    private float randomStopTime()
    {
        return Random.Range(2f, 5f);
    }

    void destroyKing()
    {
        kingDeathSound.Play();
        Destroy(gameObject,0.5f);
        BG.Stop();
        LoadWinLose.loadWin(wl);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Goal")
        {
            BG.Stop();
            BGL.Play();
            LoadWinLose.loadLose(wl);

            Destroy(gameObject, 0.5f);

        }
    }



}
