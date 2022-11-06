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
    int[] wordInLevel = new int[] { 1,1,2,2,4,6};
    int currentLevel = 0;

    //for enemy
    [SerializeField]
    float TimeBettwenSpeakWord;

    [SerializeField]
    Dialogue dialogueEnemy;

    [SerializeField]
    Dialogue dialogueCharacter;

    [SerializeField]
    TextMeshProUGUI statusGame;
    
    [SerializeField]
    Animator animatorCharacter;
    [SerializeField]
    Animator animatorEnemy;
    [SerializeField]
    LoadWinLose wl;

    [SerializeField]
    Canvas canvasDialog;

    bool enableSoundLose;
    void Start()
    {
        Manager_SBG.PlaySound(soundsGame.backgroundG1/*,1f,1f,128*/);
        nextLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && enableInputPlayer)
        {
            stringWordPlayer += " left";
            dialogueCharacter.addTextDialogue("Left");
            dialogueCharacter.displayDialouge();
            Manager_SFX.PlaySound_SFX(soundsGame.speakLeftCharacter,1f,129);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && enableInputPlayer)
        {
            stringWordPlayer += " right";
            dialogueCharacter.addTextDialogue("Right");
            dialogueCharacter.displayDialouge();

            Manager_SFX.PlaySound_SFX(soundsGame.speakRightCharacter, 1f, 129);

        }

    }

    private void LateUpdate()
    {
        if (stringWordPlayer == stringWord && enableInputPlayer)
        {
            stringWordPlayer = "";
            enableInputPlayer = false;
            statusGame.SetText("CORRECT");
            animatorEnemy.SetTrigger("Hit");

            nextLevel();
        }
        else if(!stringWord.Contains(stringWordPlayer)&& !enableSoundLose)
        {
            statusGame.SetText("Lose");
            Manager_SFX.PlaySound_SFX(soundsGame.loseG2);
            enableSoundLose = true;
            animatorCharacter.SetTrigger("Hit");
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

            if (word.Trim().Equals("right")) Manager_SFX.PlaySound_SFX(soundsGame.speakRightEnemy);
            else Manager_SFX.PlaySound_SFX(soundsGame.speakLeftEnemy);
        }
        statusGame.SetText("START");
        enableInputPlayer = true;

    }

    void nextLevel()
    {
   
        if(currentLevel < wordInLevel.Length-1)
        {
            numberWord = wordInLevel[currentLevel];
            createStringWord(numberWord);

            dialogueEnemy.addTextDialogue("");
            dialogueEnemy.displayDialouge();

            StartCoroutine(readStringWord(TimeBettwenSpeakWord));
            TimeBettwenSpeakWord = TimeBettwenSpeakWord * 0.6f;
            currentLevel++;

           
        }
        else
        {
            statusGame.SetText("Win");
            Manager_SFX.PlaySound_SFX(soundsGame.winG1);
            PlayerWin();
        }
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

    void PlayerWin()
    {
        Manager_SBG.stopPlay();
        canvasDialog.gameObject.SetActive(false);
        LoadWinLose.loadWin(wl);
        Destroy(gameObject);

    }

    void PlayerLose()
    {
        Manager_SBG.stopPlay();
        canvasDialog.gameObject.SetActive(false);
        LoadWinLose.loadLose(wl);
        Destroy(gameObject);
    }

}