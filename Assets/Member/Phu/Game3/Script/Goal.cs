using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    LoadWinLose wl;

    [SerializeField]
    SelectLevel sl;

    bool finish;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            loadCanvasWin();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            loadCanvasLose();
        }
    }

    public void loadCanvasWin()
    {
        if (!finish)
        {
            finish = true;
            Manager_SFX.PlaySound_SFX(soundsGame.winG3);
            //SceneManager.LoadScene("Game4");
            Manager_SBG.stopPlay();
            LoadWinLose.loadWin(wl);
            sl.openSceneWithColdDown();
        }
    }

    public void loadCanvasLose()
    {
        if (!finish)
        {
            finish = true;
            Manager_SFX.PlaySound_SFX(soundsGame.loseG3);
            //SceneManager.LoadScene("Game4");
            Manager_SBG.stopPlay();
            LoadWinLose.loadLose(wl);
            sl.openSceneWithColdDown();
        }
    }
}
