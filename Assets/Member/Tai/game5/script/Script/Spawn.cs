using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pipe;
    public float maxTime;
    float timer;
    public float height;
    public void Start()
    {
        timer = maxTime;
    }
    public void Update()
    {
        if (timer > maxTime)
        {
            GameObject tmp = Instantiate(pipe, new Vector3(transform.position.x, transform.position.y + Random.Range(-height, height), 0), Quaternion.identity);
            timer = 0;
            Destroy(tmp, 10f);
        }
        timer += Time.deltaTime;
    }
}
