using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] CounterTime CounterTime;
    bool isTriggerEndTime;

    [SerializeField] GameObject ActiveGameObject;
    // Start is called before the first frame update
    void Update()
    {
        if (!CounterTime.getStatusCounter() && !isTriggerEndTime)
        {
            isTriggerEndTime = true;
            gameObject.SetActive(false);
            ActiveGameObject.SetActive(true);
        }
    }
}
