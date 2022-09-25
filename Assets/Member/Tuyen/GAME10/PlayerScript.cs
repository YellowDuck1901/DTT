using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool isTouched;

    public void HiddenObj()
    {
       var childs =  transform.GetComponents<mouseMove>();
       foreach (var child in childs)
        {
            child.isHide = true;
            Debug.Log($"PlayerScript hidden: {child.isHide}");
        }
    }

    public void ShowObj()
    {
        var childs = transform.GetComponents<mouseMove>();
        foreach (var child in childs)
        {
            child.isHide = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            isTouched = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
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
