using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HindenWhenWake : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }
}
