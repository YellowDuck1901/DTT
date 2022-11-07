    using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnailScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float minX = -3f;
    public float maxX = 2.84f;
    private Vector3 dir = Vector3.left;
    public SpriteRenderer snail;
    private Animator anim;

    [SerializeField]
    LoadWinLose wl;

    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    SelectLevel sl;

    bool isTriggerWin, isTriggerLose, finish;
    // Start is called before the first frame update
    //void Start()
    //{
    //    snail = GetComponent<SpriteRenderer>();
    //    anim = GetComponent<Animator>();
    //    Manager_SBG.PlaySound(soundsGame.backgroundG2);
    //}

    private void Awake()
    {
        snail = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Manager_SBG.PlaySound(soundsGame.backgroundG2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * 3 * Time.deltaTime);

        if (transform.position.x <= -3.22)
        {
            dir = Vector3.right;
            snail.flipX = transform.position.x < -3.22;
        }
        else if (transform.position.x >= 2.7)
        {
            dir = Vector3.left;
            snail.flipX = transform.position.x > 2.77;
        }

        if (text.text.Equals("00")) {

            loadCanvasWin();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bee" && !isTriggerLose)
        {
            isTriggerLose = true;
            Manager_SFX.PlaySound_SFX(soundsGame.loseG3); 
            anim.SetTrigger("Die");
        }
    }

    public void SnailDie()
    {
        loadCanvasLose();
    }


    void loadCanvasWin()
    {
        if (!finish)
        {
            finish = true;
            Manager_SBG.stopPlay();
            Manager_SFX.PlaySound_SFX(soundsGame.winG3);
            LoadWinLose.loadWin(wl);
            sl.openSceneWithColdDown();
        }
    }


    void loadCanvasLose()
    {
        if (!finish)
        {
            finish = true;
            Manager_SBG.stopPlay();
            LoadWinLose.loadLose(wl);
            sl.openSceneWithColdDown();
        }
    }

}

