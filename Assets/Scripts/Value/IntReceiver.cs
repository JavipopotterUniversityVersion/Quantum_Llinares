using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntReceiver : MonoBehaviour
{
    [SerializeField] private Int _input;
    [SerializeField] UnityEvent<int> _onValueChanged;

    private void OnEnable()
    {
        _input.OnValueChanged.AddListener(OnValueChanged);
    }

    void OnValueChanged(int value)
    {
        _onValueChanged.Invoke(value);
    }
}
