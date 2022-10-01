using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPush : MonoBehaviour
{
    [SerializeField]
    float force;

    [Range(0f,4f), SerializeField]
    float minCountDown;

    [Range(0f, 4f), SerializeField]
    float maxCountDown;
    // Start is called before the first frame update
    Rigidbody2D rigidbody2D;
    void Start()
    {
         rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(pushUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator pushUp()
    {
        while (true)
        {
            rigidbody2D.velocity = new Vector2(0f, 0f);
            rigidbody2D.AddForce(Vector2.up * force * Time.fixedDeltaTime, ForceMode2D.Impulse);
            var second = Random.Range(minCountDown, maxCountDown);
            yield return new WaitForSeconds(second);
        }
    }


}
