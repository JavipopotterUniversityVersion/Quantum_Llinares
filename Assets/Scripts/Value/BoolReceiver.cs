using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoolReceiver : MonoBehaviour
{
    [SerializeField] Bool _bool;
    [SerializeField] UnityEvent _onTrue;
    [SerializeField] UnityEvent _onFalse;

    private void OnEnable()
    {
        _bool.OnValueChanged.AddListener(OnValueChanged);
    }

    private void OnDisable()
    {
        _bool.OnValueChanged.RemoveListener(OnValueChanged);
    }

    private void OnValueChanged()
    {
        if (_bool.Value) _onTrue.Invoke();
        else _onFalse.Invoke();
    }
}
