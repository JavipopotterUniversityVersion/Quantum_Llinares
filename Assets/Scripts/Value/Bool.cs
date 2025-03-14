using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu (fileName = "Bool", menuName = "Value/Bool")]
public class Bool : ScriptableObject
{
    [SerializeField] private bool _value;
    UnityEvent _onValueChanged;
    public UnityEvent OnValueChanged => _onValueChanged;

    public bool Value
    {
        get => _value;
        set
        {
            _value = value;
            _onValueChanged.Invoke();
        }
    }

    public void SetValue(bool value) => Value = value;
    public void Toggle() => Value = !Value;
}
