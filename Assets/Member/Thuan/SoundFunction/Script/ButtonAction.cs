using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAction : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip ClickSound;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnMouseDown()
    {
        PlayClickSound();
    }
    private void PlayClickSound() => AudioSource.PlayOneShot(ClickSound);

    // Update is called once per frame
    void Update()
    {
        
    }
}
