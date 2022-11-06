using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string GameLevel;
    void Start()
    {
        
    }

    public void openScene()
    {
        SceneManager.LoadScene(GameLevel);
    }
}
