using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private float minX=0, maxX=0, offset;
    private Vector3 a, b;
    [SerializeField]
    private float y=3;
    [SerializeField]
    GameObject box;
    private BoxScript boxScript;
    
    // Start is called before the first frame update
    void Start()
    {
        boxScript = GetComponent<BoxScript>();
        StartCoroutine(SpawnObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            y += 3;
            a = new Vector3(minX, y + offset, 0);
            b = new Vector3(maxX, y + offset, 0);
            GameObject obj = Instantiate(box,a,Quaternion.identity);
            obj.GetComponent<BoxScript>().Moving(a,b);
        
        }
    }

}
