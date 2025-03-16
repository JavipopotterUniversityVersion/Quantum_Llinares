using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tutorial : MonoBehaviour
{
    [SerializeField] StringContainer _container;

    [SerializeField] String[] _dialogs;

    private bool _basicsLearned, _divisionLearned, _powerUpFound, _entwineLearned;

    private int _index;

    public void DivisionLearned() => _divisionLearned = true;
    public void EntwineLearned() => _entwineLearned = true;
    public void PowerUpFound() => _powerUpFound = true;

    private void Start()
    {
        StartCoroutine(TutorialCoroutine());
    }

    private void RunTutorialScene()
    {
        if (_index >= _dialogs.Length) return;
        _container.SetValue(_dialogs[_index]);
        Time.timeScale = 0.0f;
        _index++;
    }

    public void UnPause()
    {
        Time.timeScale = 1.0f;
    }

    private IEnumerator TutorialCoroutine()
    {
        RunTutorialScene();

        _basicsLearned = false;
        yield return new WaitForSeconds(5);

        RunTutorialScene();

        _divisionLearned = false;
        yield return new WaitUntil(() => _divisionLearned);

        RunTutorialScene();
            
        _powerUpFound = false;
        yield return new WaitUntil(() => _powerUpFound);

        RunTutorialScene();

        _entwineLearned = false;

        yield return new WaitUntil(() => _entwineLearned);
        yield return new WaitForSeconds(5);
        RunTutorialScene();
    }
}
