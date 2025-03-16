using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionChecker : MonoBehaviour
{
    [SerializeField] Tutorial _tutorial;
    private void OnEnable()
    {
        _tutorial.DivisionLearned();
    }
}
