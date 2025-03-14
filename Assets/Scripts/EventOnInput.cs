using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EventOnInput : MonoBehaviour
{
    [SerializeField] UnityEvent _onInput;
    [SerializeField] InputActionReference _inputAction;

    private void Awake(){
        _inputAction.action.performed += OnGetInput;
    }

    private void OnDestroy() {
        _inputAction.action.performed -= OnGetInput;
    }

    void OnGetInput(InputAction.CallbackContext ctx){
        _onInput.Invoke();
    }

    private void OnEnable()
    {
        _inputAction.action.Enable();
    }

    private void OnDisable()
    {
        _inputAction.action.Disable();
    }
}
