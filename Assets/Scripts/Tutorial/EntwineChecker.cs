using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntwineChecker : MonoBehaviour
{
    private bool _division = false;
    [SerializeField] Tutorial _tutorial;

    private void OnDisable()
    {
        _division = true;
    }

    private void OnEnable()
    {
        if(_division) _tutorial.EntwineLearned();
    }
}
