using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DialogueInterpreter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] TextMeshProUGUI[] _channels;
    int channelIndex = 0;
    TextMeshProUGUI _text => _channels[channelIndex];
    [SerializeField] StringContainer _dialogue;

    [SerializeField] float timeBetweenChars = 0.05f;
    [SerializeField] float timeBetweenLines = 1.0f;
    [SerializeField] UnityEvent _onCharWritten;
    [SerializeField] UnityEvent _onLineStart;
    [SerializeField] UnityEvent _onLineEnd;
    [SerializeField] Image sr;
    [SerializeField] SerializableDictionary<string, Sprite> spriteDictionary;
    SceneLoader sceneLoader;

    [SerializeField] UnityEvent _onDialogueStart;
    [SerializeField] UnityEvent _onDialogueEnd;

    [SerializeField] SerializableDictionary<string, UnityEvent> events;
    bool _stop;

    [SerializeField] String[] dialogues;
    Dictionary<string, String> dialogueDictionary = new Dictionary<string, String>();

    public void Continue() => _stop = false;
    
    private void Awake() {
        sceneLoader = GetComponent<SceneLoader>();
        foreach(var dialogue in dialogues) dialogueDictionary.Add(dialogue.name, dialogue);

        _dialogue.OnValueChanged.AddListener(StartDialogue);
    }

    private void OnDestroy() {
        _dialogue.OnValueChanged.RemoveListener(StartDialogue);
    }

    public void StartDialogue(StringContainer dialogue) => StartCoroutine(StartDialogueRoutine(dialogue.Value));
    public void StartDialogue(String dialogue) => StartCoroutine(StartDialogueRoutine(dialogue.Value));
    public void StartDialogue(string dialogue) => StartCoroutine(StartDialogueRoutine(dialogueDictionary[dialogue].Value));

    IEnumerator StartDialogueRoutine(string dialogue)
    {   
        _onDialogueStart.Invoke();
        channelIndex = 0;
        string[] lines = dialogue.Split($"---");

        for(int c = 0; c < lines.Length; c++)
        {
            _onLineStart.Invoke();
            string line = lines[c];
            _text.text = line.Trim();
            _text.maxVisibleCharacters = 0;
            float waitTime = timeBetweenLines;
            _stop = true;

            for(int i = 0; i < _text.text.Length; i++)
            {
                _text.maxVisibleCharacters++;

                if(_text.text[i] == '<')
                {
                    string value = _text.text.Split("<")[1].Split(">")[0];
                    _text.text = _text.text.Replace("<" + value + ">", "");
                    i--;

                    ReadCommand(value, ref waitTime);
                } else if(_text.text[i] != ' ' && !Input.GetKey(KeyCode.Tab)) _onCharWritten.Invoke();

                if(Input.GetKey(KeyCode.Tab) || !_stop) yield return null;
                else yield return new WaitForSeconds(timeBetweenChars);
            }
            _stop = true;
            _onLineEnd.Invoke();
            yield return new WaitWhile(() => _stop);
            if(Input.GetKey(KeyCode.Tab)) yield return null;
            //else yield return new WaitForSeconds(waitTime);
        }

         _text.maxVisibleCharacters = 0;
        _onDialogueEnd.Invoke();
    }

    public void Next(InputAction.CallbackContext context) => _stop = false;

    public void ReadCommand(string command)
    {
        float refTime = timeBetweenLines;
        ReadCommand(command, ref refTime);
    }

    public void ReadCommand(string command, ref float waitTime)
    {
        string value = command.Split(":", 2)[0].Trim();
        string arg = command.Split(":", 2)[1].Trim();

        if(value == "c")
        {
            sr.sprite = spriteDictionary[arg];
        }
        else if(value == "event") events[arg].Invoke();
        else if(value == "w") waitTime = float.Parse(arg);
        else if(value == "dialogue")
        {
            StopAllCoroutines();
            StartDialogue(Resources.Load<String>(arg));
        }
        else if(value == "channel")
        {
            _channels[channelIndex].text = "";
            channelIndex = int.Parse(arg);
        }
        else if(value == "load")
        {
            string[] subArgs = arg.Split("/");
            if(subArgs.Length > 1)
            {
                if(subArgs.Length > 2)sceneLoader.LoadScene(subArgs[0], subArgs[1] == "white", () => ReadCommand(subArgs[2]));
                else sceneLoader.LoadScene(subArgs[0], subArgs[1] == "white");
            }
            else sceneLoader.LoadScene(arg);
        }
        else if(value == "iload") sceneLoader.LoadSceneInstantly(arg);
        else if(value == "set")
        {
            string stringRef = arg.Split("=")[0];
            string dialogueName = arg.Split("=")[1];
            StringContainer container = Resources.Load<StringContainer>("Dialogues/" + stringRef);
            container.SetValue(dialogueDictionary[dialogueName]);
        }
        else if(value == "charTime") timeBetweenChars = float.Parse(arg);
        else if(value == "name") _nameText.text = arg;
    }
}
