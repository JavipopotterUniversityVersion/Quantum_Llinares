using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tutorial : MonoBehaviour
{
    [SerializeField] StringContainer _container;

    [SerializeField] String[] _dialogs;

    private bool _divisionLearned, _powerUpFound, _entwineLearned, _waitEnded;

    private int _index;

    public void DivisionLearned() => _divisionLearned = true;
    public void EntwineLearned()
    {
        _entwineLearned = true;
        Wait();
    }

    public void PowerUpFound() => _powerUpFound = true;

    private void Start()
    {
        StartCoroutine(TutorialCoroutine());
    }

    private void RunTutorialScene()
    {
        if (_index >= _dialogs.Length) return;
        _container.SetValue(_dialogs[_index]);
        _index++;
    }

    private IEnumerator TutorialCoroutine()
    {
        RunTutorialScene();

        _waitEnded = false;
        yield return new WaitUntil(() =>_waitEnded);

        RunTutorialScene();

        _divisionLearned = false;
        yield return new WaitUntil(() => _divisionLearned);

        RunTutorialScene();
            
        _powerUpFound = false;
        yield return new WaitUntil(() => _powerUpFound);

        RunTutorialScene();

        _entwineLearned = false;
        yield return new WaitUntil(() => _entwineLearned);

        RunTutorialScene();

        _waitEnded = false;
        yield return new WaitUntil(() => _waitEnded);

        RunTutorialScene();
    }

    public void Wait() => StartCoroutine(WaitTen());

    private IEnumerator WaitTen()
    {
        yield return new WaitForSeconds(8);
        _waitEnded = true;
    }
}
