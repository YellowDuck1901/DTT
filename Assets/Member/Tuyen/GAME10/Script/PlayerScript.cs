using Assets.Member.Thuan.Public;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public bool isTouched; // kiem tra player co dung vao vat can khong
    /*an tat ca cac object button*/
    private Animator anim;
    [SerializeField] private AudioSource touchAudio;
    [SerializeField] private AudioSource win;
    [SerializeField] private AudioSource lose;
    [SerializeField] private AudioSource BG;

    private float yPosition;
    Renderer m_Renderer;
    bool finish;
    [SerializeField] LoadWinLose wl;

    [SerializeField] SelectLevel sl;

    public void HiddenObj()
    {
        anim.SetBool("running", true);
        var childs = transform.GetComponentsInChildren<mouseMove>();
        foreach (var child in childs)
        {
            child.isEnable = false;
            Debug.Log($"PlayerScript hidden: {child.isEnable}");
        }

    }

    /*hien thi tat ca cac object button*/
    public void ShowObj()
    {
        var childs = transform.GetComponentsInChildren<mouseMove>();
        anim.SetBool("running", false);
        foreach (var child in childs)
        {
            switch (child.tag)
            {
                case "Up":
                    child.transform.position = (transform.position + new Vector3(0f, 1f));
                    break;
                case "Down":
                    child.transform.position = (transform.position + new Vector3(0f, -2f));
                    break;
                case "Left":
                    child.transform.position = (transform.position + new Vector3(-yPosition, -0.5f));
                    break;
                case "Right":
                    child.transform.position = (transform.position + new Vector3(yPosition, -0.5f));
                    break;
            }
            child.isEnable = true;
        }
    }

    /*player dung vao vat can*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Goal")
        {
            isTouched = true;
            touchAudio.Play();
        }
        else if (collision.gameObject.tag == "Goal") {
            PlayerWin();
        }


        if (collision.gameObject.tag == "Enemy")
        {
            PlayerLose();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        yPosition = 1.5f;
        m_Renderer = GetComponent<Renderer>();

    }

    void PlayerWin()
    {
        if (!finish)
        {
            finish = true;
            BG.Stop();
            LoadWinLose.loadWin(wl);
            sl.openSceneWithColdDown();
        }
    }

    void PlayerLose()
    {
        if (!finish)
        {
            finish = true;

            lose.Play();
            BG.Stop();
            LoadWinLose.loadLose(wl);
            sl.openSceneWithColdDown();
        }
    }
}
