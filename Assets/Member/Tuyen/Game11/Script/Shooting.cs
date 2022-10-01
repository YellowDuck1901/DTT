using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var bullet = GameObject.Instantiate(bulletPrefab, transform.position + Vector3.down, Quaternion.identity);
            var bulletScript = bullet.GetComponent<BulletScript>();
            bulletScript.shoot(Vector2.down, 20);
        }
    }
}
