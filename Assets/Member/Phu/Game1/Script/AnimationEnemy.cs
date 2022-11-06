using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    LoadWinLose wl;

    void PlayerWin()
    {
        LoadWinLose.loadWin(wl);

    }

    void PlayerLose()
    {
        LoadWinLose.loadLose(wl);

    }
}
