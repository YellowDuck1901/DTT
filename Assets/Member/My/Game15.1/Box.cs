using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Box : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float rate;

    [SerializeField]
    LoadWinLose wl;

    Rigidbody2D rig;

    private bool isMove,isHitAnamiation = true,shouldFollow;

    private Vector3 PositionTager;

    private Animator animator;

    private Renderer renderer;

    private bool stillCondition = false;

    [SerializeField]
    CinemachineVirtualCamera cam;

    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position,PositionTager, Time.deltaTime * rate);
        }
    }
    private void LateUpdate()
    {
        if (!renderer.isVisible && rig.bodyType.Equals(RigidbodyType2D.Dynamic) && !stillCondition)
        {
            cam.Follow = gameObject.transform;
        }
    }


    private void OnMouseDown()
    {
        rig.bodyType = RigidbodyType2D.Dynamic;
        TurnOffMove();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            animator.SetTrigger("Die");
            Manager_SFX.PlaySound_SFX(soundsGame.collisionBullet);
        }

         if(collision.gameObject.tag == "Object" && isHitAnamiation)
        {
            animator.SetTrigger("Hit");
            Manager_SFX.PlaySound_SFX(soundsGame.collisionBullet);
        }
        stillCondition = true;
        shouldFollow = false;


    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isHitAnamiation = false;
        stillCondition = true;
        shouldFollow = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ShouldFollow(0.1f);
    }

    IEnumerator ShouldFollow(float time)
    {
        shouldFollow = true;
        yield return new WaitForSeconds(time);
        if (shouldFollow) stillCondition = false;
    }


    public void TurnOnMove(Vector3 target)
    {
        this.PositionTager = target;
        isMove = true;
    }

    public void TurnOffMove()
    {
        isMove= false;
    }
    void loadCanvasWin()
    {
        Manager_SFX.PlaySound_SFX(soundsGame.winG1);

        LoadWinLose.loadWin(wl);
    }

    void loadCanvasLose()
    {
        Manager_SFX.PlaySound_SFX(soundsGame.loseG1);

        LoadWinLose.loadLose(wl);

    }

}
