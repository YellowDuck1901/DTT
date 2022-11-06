using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
using UnityEngine.SceneManagement;
using System;

public class DirectionGun2D : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector3 directionGun;

    private Animator animator;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //cameraPosition = Camera.main.ScreenToViewportPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y));
        //transform.LookAt(cameraPosition);
        //Debug.Log(cameraPosition);
        //Vector3 newRotation = new Vector3(0, 190, 0);
        //transform.eulerAngles = newRotation;


        directionGun = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        directionGun.z = 0;  //2d phong ho loi
        directionGun = directionGun.normalized; // keep direction and set value of coordinate in range 0-1

        var angle = Mathf.Atan2(directionGun.y, directionGun.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        var z = transform.eulerAngles.z;
        if (z >= 90 && z <= 180 || z >= 180 && z <= 270)
        transform.eulerAngles = new Vector3(-180, 0, - transform.eulerAngles.z);
    }


    void rotationLeftRight()
    {
        
        //if (left)
        //{
        //    //default
        //}else if (right)
        //{
        //    transform.LookAt
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Console.WriteLine("Die");
            animator.SetTrigger("Die");
        }
    }

    void die()
    {
        SceneManager.LoadScene("Game3");
    }
}
