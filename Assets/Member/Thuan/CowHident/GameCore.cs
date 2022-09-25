using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    float height; float width;
    public AudioSource AudioSource;
    public AudioClip Cowsound;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(true);
        Camera cam = Camera.main;
         height = cam.orthographicSize * 2f;
         width = height * cam.aspect;
        transform.position= new Vector3(Random.Range(-10 , 10), Random.Range(-5, 5), transform.position.z);
        //gameObject.hideFlags = HideFlags.HideInInspector;
        gameObject.GetComponent<Renderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        

            var posion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var cowP = transform.position;

            float volum = 1 - Mathf.Sqrt(Mathf.Pow((posion.y - cowP.y),2)+ Mathf.Pow((posion.x - cowP.x), 2));
            AudioSource.volume = 1/Mathf.Abs(volum);
            AudioSource.clip = Cowsound;
            AudioSource.Play();

        }
            if (AudioSource.time > 1.5f)
                AudioSource.Stop();
    }

    private void OnMouseDown()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        
        Debug.Log("found!");
    }

}
