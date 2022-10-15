using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public bool isTouched; // kiem tra player co dung vao vat can khong
    /*an tat ca cac object button*/
    private Animator anim;
    [SerializeField] private AudioSource touchAudio;
    private float yPosition;
    Renderer m_Renderer;
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
    }


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        yPosition = 1.5f;
        m_Renderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (m_Renderer.isVisible)
        {
            Debug.Log("Object is visible");
        }
        else Debug.Log("GAME OVER");
    }

}
