using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            G3_Sound.PlaySound(soundsGame.winG3);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            G3_Sound.PlaySound(soundsGame.loseG3);
        }
    }
}
