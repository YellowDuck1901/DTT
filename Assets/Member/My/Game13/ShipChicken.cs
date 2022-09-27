using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipChicken : MonoBehaviour
{
    //public GameObject explosion;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("da cham");
        //GameObject e = Instantiate(explosion) as GameObject;
        //e.transform.position = transform.position;
        Destroy(collision.gameObject);
        collision.gameObject.SetActive(false);
    }
}
