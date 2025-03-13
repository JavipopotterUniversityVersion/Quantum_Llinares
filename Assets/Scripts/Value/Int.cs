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
}
