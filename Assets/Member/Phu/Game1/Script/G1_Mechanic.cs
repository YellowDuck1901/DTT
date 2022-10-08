using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using TMPro;

public class G1_Mechanic : MonoBehaviour
{
    // Start is called before the first frame update
    int numberWord = 1;
    string stringWord = "";
    string stringWordPlayer = "";
    bool enableInputPlayer = false;

    [SerializeField]
    Dialogue dialogueEnemy;

    [SerializeField]
    Dialogue dialogueCharacter;

    [SerializeField]
    TextMeshProUGUI statusGame;
    
    [SerializeField]
    AudioClip left;
    [SerializeField]
    AudioClip right;
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
            dialogueCharacter.addTextDialogue("Left");
            dialogueCharacter.displayDialouge();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && enableInputPlayer)
        {
            stringWordPlayer += " right";
            dialogueCharacter.addTextDialogue("Right");
            dialogueCharacter.displayDialouge();
        }

    }

    private void LateUpdate()
    {
        if (stringWordPlayer == stringWord && enableInputPlayer)
        {
            stringWordPlayer = "";
            ClearConsole();
            enableInputPlayer = false;
            statusGame.SetText("CORRECT");
            nextLevel(1);
        }
        else if(!stringWord.Contains(stringWordPlayer))
        {
            statusGame.SetText("FAILLL");
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
            statusGame.SetText("Watting");
            dialogueEnemy.addTextDialogue(word);
            dialogueEnemy.displayDialouge();
        }
        statusGame.SetText("START");
        enableInputPlayer = true;

    }

    void nextLevel(int increaseNumber)
    {
        numberWord += increaseNumber;
        createStringWord(numberWord);
        StartCoroutine(readStringWord(2f));
        
    }

    public static void ClearConsole()
    {
        var assembly = Assembly.GetAssembly(typeof(SceneView));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }

    IEnumerator waitforSecond(float second)
    {
        while(true)
        yield return new WaitForSeconds(second);
    }

}