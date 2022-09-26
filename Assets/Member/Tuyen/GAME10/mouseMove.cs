using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMove : MonoBehaviour
{
    public float speed = 20f;
    private float x, y;
    public bool isEnable; // trang thai co the nhin thay khong cua obj button
    private bool isActive; // dung de kiem tra object button hien tai co duoc bam vao khong
    public void OnMouseDown()
    {
        if (isEnable) //neu object buton hien tai co the duoc nhin thay
        {
        Debug.Log(string.Concat(new string('*', 30), "Start mouseDown"));
        isActive = true; // gan cho object button biet la da duoc bam vao
        transform.parent.GetComponentInParent<PlayerScript>().isTouched = false; // Player khong cham vao gi
        transform.parent.GetComponentInParent<PlayerScript>().HiddenObj(); //Ham an cac button
        Debug.Log($"isEnable = {isEnable} ");
        Debug.Log($"transform.tag = {transform.tag} ");
        Debug.Log(string.Concat(new string('*', 30), "End mouseDown"));
        }


    }

    public void DetachFromParent()
    {
        // Detaches the transform from its parent.
        transform.parent = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        isEnable = true; //object button duoc cho phep nhin thay
        isActive = false; //object button hien tai khong duoc bam vao
        /*kiem tra object button hien tai la nut nao va gan gia tri huong cho object button do*/
        if (transform.tag == "Left")
        {
            x = -1;
            y = 0;
        }
        else if (transform.tag == "Right")
        {
            x = 1;
            y = 0;
        }
        else if (transform.tag == "Up")
        {
            y = 1;
            x = 0;
        }
        else if (transform.tag == "Down")
        {
            x = 0;
            y = -1;
        }
        else
        {
            Debug.Log($"x = {x}, y = {y} ERROR");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!transform.parent.GetComponentInParent<PlayerScript>().isTouched && isActive && isEnable == false) //Player phai trong trang thai khong dung, object button hien tai da duoc bam va object button da duoc an
        {
            transform.parent.position += new Vector3(x, y, 0) * speed * Time.deltaTime;
        }

        if (transform.parent.GetComponentInParent<PlayerScript>().isTouched) //neu player bi dung vao vat can thi hien thi cac object button va object button hien tai dung hoat dong
        {
            transform.parent.GetComponentInParent<PlayerScript>().ShowObj();
            isActive = false;
        }
        gameObject.GetComponent<Renderer>().enabled = isEnable; //set an hien object button
    }

}
