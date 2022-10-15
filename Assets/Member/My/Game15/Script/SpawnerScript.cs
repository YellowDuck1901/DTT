using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private float minX=0, maxX=0, offset;
    private Vector3 a, b;
    private float y=5;
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
            //y += box.transform.localScale.y;
            y+=3;
            a = new Vector3(minX, y + offset, 0);
            b = new Vector3(maxX, y + offset, 0);
            GameObject obj = Instantiate(box,a,Quaternion.identity);
            obj.GetComponent<BoxScript>().Moving(a,b);
            yield return new WaitForSeconds(3);
        
        }
    }

}
