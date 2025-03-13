using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Value/Int")]
public class Int : ScriptableObject
{
    UnityEvent<int> _onValueChanged = new UnityEvent<int>();
    public UnityEvent<int> OnValueChanged => _onValueChanged;
    [SerializeField] int _value;
    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            _onValueChanged.Invoke(_value);
        }
    }

    public void AddValue(int value)
    {
        Value += value;
    }

    public void SubValue(int value)
    {
        Value -= value;
    }

    public void SetValue(int value)
    {
        Value = value;
    }

    public void MultiplyValue(int value)
    {
        Value *= value;
    }

    public void DivideValue(int value)
    {
        Value /= value;
    }
}
