using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    [TextArea]
    private List<string> _dialogueLines;
    private int _lineIndex;

    private TMP_Text _text;
    private CanvasGroup _group;
    private bool _started;
        
    void Start()
    {
        _text = GetComponent<TMP_Text>();
        _group = GetComponent<CanvasGroup>();
        _group.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (!_started)
        //    {
        //        _lineIndex = 0;
        //        _text.SetText(_dialogueLines[_lineIndex]);
        //        _group.alpha = 1;
        //        _started = true;
        //    }
        //    else if (_lineIndex < _dialogueLines.Count)
        //    {
        //        _text.SetText(_dialogueLines[_lineIndex++]);
        //    }
        //    else
        //    {
        //        _group.alpha = 0;
        //    }
        //}
    }

    private void OnValidate()
    {
        if(_dialogueLines.Count > 0)
        {
            if (_text == null) _text = GetComponent<TMP_Text>();
            _text.SetText(_dialogueLines[0]);
        }
    }

    public void displayDialouge()
    {
        if (!_started)
        {
            _lineIndex = 0;
            _text.SetText(_dialogueLines[_lineIndex]);
            _group.alpha = 1;
            _started = true;
        }
        else if (_lineIndex < _dialogueLines.Count)
        {
            _text.SetText(_dialogueLines[_lineIndex]);
        }
        else
        {
            _group.alpha = 0;
        }
    }

   

    public void addTextDialogue(string dialogueText)
    {
        _dialogueLines.Add( dialogueText);
        _lineIndex++;
    }
}
