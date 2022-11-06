using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWinLose : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject win,lose;
    public static bool isLoadCanvasWin, isLoadCanvasLose;
     void isVisibleWin(bool b)
    {
        if (!lose.active) //load when un visible
        {
            Time.timeScale = 0;
            win.SetActive(b);
        }
        else //unload
        {
            Time.timeScale = 1;
            win.SetActive(b);
        }
    }

     void isVisibleLose(bool b)
    {
        if (!lose.active) //load when un visible
        {
            Time.timeScale = 0;
            lose.SetActive(b);
        }
        else //unload
        {
            Time.timeScale = 1;
            lose.SetActive(b);
        }
    }

    public static void loadWin(LoadWinLose wl)
    {
        isLoadCanvasWin = true;
        wl.isVisibleWin(true);
    }

    public static void unLoadWin(LoadWinLose wl)
    {
        isLoadCanvasWin = false;
        wl.isVisibleWin(false);
    }
    public static void loadLose(LoadWinLose wl)
    {
        isLoadCanvasLose = true;
        wl.isVisibleLose(true);
    }

    public static void unLoadLose(LoadWinLose wl)
    {
        isLoadCanvasLose = false;
        wl.isVisibleLose(false);
    }
}
