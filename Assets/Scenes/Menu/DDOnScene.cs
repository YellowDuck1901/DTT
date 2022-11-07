using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOnScene : MonoBehaviour
{
    // Start is called before the first frame update
    private static DDOnScene pause;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (pause == null)
        {
            pause = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }
}

