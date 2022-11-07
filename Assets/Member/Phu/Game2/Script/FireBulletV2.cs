using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletV2 : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float speed;

    [SerializeField]
    Transform shotPosition;

    [SerializeField]
    Animator anim;

    [SerializeField]
    LoadWinLose wl;

    [SerializeField]
    CounterTime counterTime;

    [SerializeField]
    SelectLevel sl;

    private bool isTriggerAnim;

    bool finish;
    void Start()
    {
        Manager_SBG.PlaySound(soundsGame.backgroundG2);
        //StartCoroutine(shotBullet());
    }

    // Update is called once per frame
    void Update()
    {
        if (!counterTime.getStatusCounter())
        {
            Manager_SFX.PlaySound_SFX(soundsGame.winG2);
            loadCanvasWin();    
        }
    }


    void shotBulletEachAnimation()
    {
        Manager_SFX.PlaySound_SFX(soundsGame.fire);
        GameObject gameObject = (GameObject)Instantiate(bullet, shotPosition.position, Quaternion.identity);
        var rig = gameObject.GetComponent<Rigidbody2D>();
        rig.velocity = new Vector3(DirectionGun2D.directionGun.x * speed, DirectionGun2D.directionGun.y * speed) * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy" && !isTriggerAnim)
        {

            anim.SetTrigger("DDIE");

            isTriggerAnim = true;
        }
    }

    public void loadCanvasWin()
    {
        if (!finish)
        {
            finish = true;
            Manager_SBG.stopPlay();
            LoadWinLose.loadWin(wl);
            sl.openSceneWithColdDown();
        }
    }

    public void loadCanvasLose()
    {
        if (!finish)
        {
            finish = true;
            Manager_SFX.PlaySound_SFX(soundsGame.loseG1);
            Manager_SBG.stopPlay();
            LoadWinLose.loadLose(wl);
            sl.openSceneWithColdDown();
        }
    }
}
