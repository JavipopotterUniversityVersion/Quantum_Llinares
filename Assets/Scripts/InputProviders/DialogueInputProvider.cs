using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueInputProvider : MonoBehaviour
{
    [SerializeField] private InputActionReference _goNext;

    [SerializeField] private DialogueInterpreter _interpreter;

    private void OnEnable()
    {
        _goNext.action.Enable();
    }

    private void Awake()
    {
        _goNext.action.performed += _interpreter.Next;
    }

    private void OnDestroy()
    {
        _goNext.action.performed -= _interpreter.Next;
    }

    private void OnDisable()
    {
        _goNext.action.Disable();
    }
}
