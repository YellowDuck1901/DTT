using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hit : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private string NextGame;

    void nextGame()
    {
        SceneManager.LoadScene(NextGame);
    }
}
    
