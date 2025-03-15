using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] StringContainer _container;

    [SerializeField] String[] _dialogs;

    private int _index;
    private void Start()
    {
        RunTutorialScene();
    }

    private void RunTutorialScene()
    {
        Time.timeScale = 0.0f;
        _container.SetValue(_dialogs[_index]);
    }

    public void UnPause()
    {
        Time.timeScale = 1.0f;
    }

    public void advanceInTutorial()
    {
        if (_index >= _dialogs.Length) return;
        _index++;
        RunTutorialScene();
    }
}
