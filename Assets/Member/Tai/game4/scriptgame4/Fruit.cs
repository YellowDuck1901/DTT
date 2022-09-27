using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] GameObject[] fruitPrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;

    
    void Start()
    {
        StartCoroutine(FruitSpawn());
    }

    IEnumerator FruitSpawn()  
    {
        while (true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
          
            GameObject gameObject = Instantiate(fruitPrefab[Random.Range(0, fruitPrefab.Length)], position, Quaternion.identity); //radom xong khoi tao
            yield return new WaitForSeconds(secondSpawn); // đợi tầm x giây ròi ms tiếp tục lại while
            Destroy(gameObject, 5f); // hủy obj
           
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
