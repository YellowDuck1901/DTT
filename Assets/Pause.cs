using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pause;
    [SerializeField] GameObject pauseR;

    [SerializeField]
    List<GameObject> listHiden;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause.active)
            {
                pauseR.SetActive(false);
                pause.SetActive(false);
                actionRemuse();
                listHiden.ForEach(c => { c.active = true; });

            }
            else {
                pauseR.SetActive(true);
                pause.SetActive(true);
                actionPause();
                listHiden.ForEach(c => { c.active = false; });
            } 
        }
    }

    public static void actionRemuse()
    {
        Time.timeScale = 1; //normal
        AudioListener.pause = false;
        InputSystem.EnableDevice(Mouse.current);
    }

    public static void actionPause()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        InputSystem.DisableDevice(Mouse.current);
    }
   


}
