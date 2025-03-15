using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntWriter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] string _prefix;
    [SerializeField] Int _value;

    private void OnEnable() {
        _value.OnValueChanged.AddListener(OnIntChanged);
    }

    public void OnIntChanged(int value) {
        _text.text = _prefix + _value.Value.ToString();
    }
}
