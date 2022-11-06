using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OMDBee : MonoBehaviour
{
    public GameObject bee;
    private void OnMouseDown()
    {
        Manager_SFX.PlaySound_SFX(soundsGame.collisionBullet);
        Destroy(bee);
    }
}
