using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using System.Reflection;

public class G1_Mechanic : MonoBehaviour
{
    // Start is called before the first frame update
    int numberWord = 1;
    string stringWord = "";
    string stringWordPlayer = "";
    bool enableInputPlayer = false;
    void Start()
    {

        nextLevel(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && enableInputPlayer)
        {
            stringWordPlayer += " left";
            Debug.Log("User LEFT");
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && enableInputPlayer)
        {
            stringWordPlayer += " right";
            Debug.Log("User right");
        }

    }


    private void LateUpdate()
    {
        if (stringWordPlayer == stringWord && enableInputPlayer)
        {
            stringWordPlayer = "";
            ClearConsole();
            Debug.Log("Finish");
            enableInputPlayer = false;
            Debug.Log("Endable : " + enableInputPlayer);
            nextLevel(1);
        }
    }
    void createStringWord(int numberWord)
    {
        for (int i = 0; i < numberWord; i++)
        {
            int wordType = Random.Range(1, 3);
            if (wordType == 1) //left
            {
                stringWord += " left";
            }
            else if (wordType == 2) stringWord += " right";
        }
    }

    IEnumerator readStringWord(float countDown)
    {
        string[] arrayWord = stringWord.Trim().Split(' ');
        foreach (string word in arrayWord)
        {
            
            yield return new WaitForSeconds(countDown);
        }
        Debug.Log(stringWord);
        enableInputPlayer = true;
        Debug.Log("Endable : " + enableInputPlayer);

    }

    void nextLevel(int increaseNumber)
    {
        numberWord += increaseNumber;
        createStringWord(numberWord);
        StartCoroutine(readStringWord(0.5f));
    }

    public static void ClearConsole()
    {
        var assembly = Assembly.GetAssembly(typeof(SceneView));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }

}