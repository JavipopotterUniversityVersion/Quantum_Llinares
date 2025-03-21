using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    private TMP_Dropdown _mdropdown;
    [SerializeField] LanguageSelector _mSelector;
    [SerializeField] AudioChannel _mainChannel;
    [SerializeField] AudioPlayer _galicianTheme, _mainTheme;
    void Start()
    {
        _mdropdown = GetComponent<TMP_Dropdown>();
        _mdropdown.onValueChanged.AddListener(ChangeLanguage);

        _mainChannel.Play(_mainTheme);
        _mSelector.Language = (LanguageSelector.Languages)1;
    }
    public void ChangeLanguage(int value){
        if(value == 1)  _mainChannel.Play(_galicianTheme);
        else _mainChannel.Play(_mainTheme);

        _mSelector.Language = (LanguageSelector.Languages) value;
    }
}
