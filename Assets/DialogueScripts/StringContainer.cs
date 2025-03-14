using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "StringContainer", menuName = "StringContainer", order = 0)]
public class StringContainer : ScriptableObject {
    
    [SerializeField] String _value;
    UnityEvent<String> _onValueChanged = new UnityEvent<String>();
    public UnityEvent<String> OnValueChanged => _onValueChanged;

    public string Value => _value.Value;

    public void SetValue(String value)
    {
        _value = value;
        _onValueChanged.Invoke(_value);
    }
}
