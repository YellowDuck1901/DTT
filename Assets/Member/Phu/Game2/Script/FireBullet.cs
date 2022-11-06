using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float secondSpawn;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float speed;

    void Start()
    {
        //StartCoroutine(shotBullet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator shotBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondSpawn);
            Manager_SFX.PlaySound_SFX(soundsGame.fire);
            GameObject gameObject = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
            var rig = gameObject.GetComponent<Rigidbody2D>();
            rig.velocity = new Vector3(DirectionGun2D.directionGun.x * speed,DirectionGun2D.directionGun.y * speed) * Time.fixedDeltaTime;
        }
    }


    void shotBulletEachAnimation()
    {
        Manager_SFX.PlaySound_SFX(soundsGame.fire);
        GameObject gameObject = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        var rig = gameObject.GetComponent<Rigidbody2D>();
        rig.velocity = new Vector3(DirectionGun2D.directionGun.x * speed, DirectionGun2D.directionGun.y * speed) * Time.fixedDeltaTime;
    }

}
