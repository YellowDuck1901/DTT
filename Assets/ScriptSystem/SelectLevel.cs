using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
     private string NextSence;

    [SerializeField]
    private float ColdDownTime;

    static private string staticSence;

    private void Start()
    {
        staticSence = NextSence;
    }
    public IEnumerator WithColdDown()
    {
        while (true)
        {
            Debug.Log("slectLevel");
            yield return new WaitForSeconds(ColdDownTime);
            SceneManager.LoadScene(NextSence);
            break;
        }
    }

    public void openSceneWithColdDown()
    {
        StartCoroutine(WithColdDown());
    }

    public static void openSceneWithoutColdDown()
    {
            SceneManager.LoadScene("Game1");
            LoadWinLose.isLoadCanvasLose = false;
            LoadWinLose.isLoadCanvasWin = false;

    }
}
