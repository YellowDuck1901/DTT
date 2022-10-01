using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDiagloue : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    TextAsset inkJson;

    Story story;
    void Start()
    {
        story = new Story(inkJson.text);
        Debug.Log(loadStoryChuck());
        
        for(int i = 0; i < story.currentChoices.Count; i++)
        {
            Debug.Log(story.currentChoices[i].text);
        }

        story.ChooseChoiceIndex(0);

        Debug.Log(loadStoryChuck());

        Debug.Log(loadStoryChuck());


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string loadStoryChuck()
    {
        string text = "";
        if (story.canContinue)
        {
            text =  story.ContinueMaximally();
        }

        return text;
    }

}
