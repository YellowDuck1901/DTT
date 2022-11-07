using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipChicken : MonoBehaviour
{
    //public GameObject explosion;
    private Animator anim;

    [SerializeField]
    CollectCount collect;

    [SerializeField]
    LoadWinLose lw;

    [SerializeField]
    SelectLevel sl;

    bool isTriggerWin, isTriggerLose, finish;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (collect.isCollected())
        {
            loadCanvasWin();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("da cham");
        if (collision.tag == "boom" && !isTriggerLose)
        {
            isTriggerLose = true;
            //Debug.Log("chet");
            anim.SetTrigger("Die");
            Manager_SFX.PlaySound_SFX(soundsGame.loseG2); ;


        }
        else if (collision.tag == "fruit")
        {
            collect.collect();
            Manager_SFX.PlaySound_SFX(soundsGame.collisionBullet);
        }
        //GameObject e = Instantiate(explosion) as GameObject;
        //e.transform.position = transform.position;
        Destroy(collision.gameObject);
        collision.gameObject.SetActive(false);
    }

    void checkDie()
    {
        loadCanvasLose();
    }


    void loadCanvasWin()
    {
        if (!finish)
        {
            Manager_SBG.stopPlay();
            Manager_SFX.PlaySound_SFX(soundsGame.winG2);
            LoadWinLose.loadWin(lw);
            sl.openSceneWithColdDown();
        }
    }


    void loadCanvasLose()
    {
        if (!finish)
        {
            Manager_SBG.stopPlay();
            LoadWinLose.loadLose(lw);
            sl.openSceneWithColdDown();
        }
    }
}
