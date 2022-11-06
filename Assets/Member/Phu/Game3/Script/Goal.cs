using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    LoadWinLose wl;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Manager_SFX.PlaySound_SFX(soundsGame.winG3);
            //SceneManager.LoadScene("Game4");
            Manager_SBG.stopPlay();
            LoadWinLose.loadWin(wl);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Manager_SFX.PlaySound_SFX(soundsGame.loseG3);
            //SceneManager.LoadScene("Game4");
            Manager_SBG.stopPlay();
            LoadWinLose.loadLose(wl);
        }
    }
}
