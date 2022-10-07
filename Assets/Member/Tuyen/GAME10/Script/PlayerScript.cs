using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool isTouched; // kiem tra player co dung vao vat can khong
    /*an tat ca cac object button*/
    public void HiddenObj()
    {
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
        foreach (var child in childs)
        {
            switch (child.tag)
            {
                case "Up":
                    child.transform.position = (transform.position + new Vector3(0f, 5f));
                    break;
                case "Down":
                    child.transform.position = (transform.position + new Vector3(0f, -5f));
                    break;
                case "Left":
                    child.transform.position = (transform.position + new Vector3(-5f, 0));
                    break;
                case "Right":
                    child.transform.position = (transform.position + new Vector3(5f, 0));
                    break;
            }
            child.isEnable = true;
        }
    }

    /*player dung vao vat can*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isTouched = true;
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
