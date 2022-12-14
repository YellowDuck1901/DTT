using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 1.25f;
    bool toggle;
    private Vector3 target;
    private Animator anim;
    private CamScript camScript;
    [SerializeField] private AudioSource playerAttackSound;

    [SerializeField] private AudioSource BG;

    [SerializeField]
    Animator animKing;

    [SerializeField]
    LoadWinLose wl;

    [SerializeField]
    SelectLevel sl;

    bool isTriggerWin, isTriggerLose, finish;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        gameObject.transform.localScale = new Vector3(-1, 1, 1);
        anim = GetComponent<Animator>();
        camScript = Camera.main.GetComponent<CamScript>();  
        camScript.isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            toggle = !toggle;
            camScript.isMoving = toggle;
        }else if(Input.GetMouseButtonUp(0))
        {
            toggle = !toggle;
            camScript.isMoving = toggle;
        }
        if (toggle)
        {
            target.x = transform.position.x + 1;
            target.y = transform.position.y;
            target.z = transform.position.z;
            anim.SetBool("running", true);
        }
        else
        {
            target.x = transform.position.x;
            target.y = transform.position.y;
            target.z = transform.position.z;
            anim.SetBool("running", false);
        }
        //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            anim.SetBool("attack", true);
            playerAttackSound.Play();
            toggle = false;
        }
    }

    void kingDead()
    {
        animKing.SetBool("dealth", true);
    }

    void loadCanvasWin()
    {
        if (!finish)
        {
            finish = true;
            BG.Stop();
            LoadWinLose.loadWin(wl);
            sl.openSceneWithColdDown();
        }
    }


    void loadCanvasLose()
    {
        if (!finish)
        {
            finish = true;
            BG.Stop();
            LoadWinLose.loadLose(wl);
            sl.openSceneWithColdDown();
        }
    }

}
