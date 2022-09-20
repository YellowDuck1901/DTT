using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    // Start is called before the first frame update

    public bool zoomActive;
    public Vector3[] target;
    public Camera cam;
    public float speed;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void LateUpdate()
    {
        if (zoomActive)
        {
            ZoomMethod(3);
            MoveCamera(target[1]);
        }
        else
        {
            ZoomMethod(5);
            MoveCamera(target[0]);

        }
    }
    private void ZoomMethod(float orthographicSize_Result)
    {
       
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, orthographicSize_Result, speed * Time.fixedDeltaTime);
        cam.transform.position = Vector3.Lerp(cam.transform.position, target[1], speed * Time.fixedDeltaTime); 
    }

    private void MoveCamera(Vector3 position)
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, position, speed * Time.fixedDeltaTime);

    }
}
