using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip Cowsound;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var posion = Input.mousePosition;
            var cowP = transform.position;

            float volum = cowP.x / posion.x;
            AudioSource.volume = volum;
            AudioSource.PlayOneShot(Cowsound);
        }
    }
}
