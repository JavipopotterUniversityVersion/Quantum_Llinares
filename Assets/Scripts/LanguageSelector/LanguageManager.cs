using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    private TMP_Dropdown _mdropdown;
    [SerializeField] LanguageSelector _mSelector;
    void Start()
    {
        _mdropdown = GetComponent<TMP_Dropdown>();
        _mdropdown.onValueChanged.AddListener(ChangeLanguage);
        ChangeLanguage(0);
    }
    public void ChangeLanguage(int value){
        _mSelector.Language = (LanguageSelector.Languages) value;
        Debug.Log((LanguageSelector.Languages) value);
    }
}
