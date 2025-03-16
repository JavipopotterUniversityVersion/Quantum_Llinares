using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bool", menuName = "ScriptableObjects/LanguageSelector")]
public class LanguageSelector : ScriptableObject
{
    public enum Languages
    {
        ESPANYOL,
        GALLEGO
    }

    private Languages _language = Languages.ESPANYOL;

    public Languages Language { get { return _language; } set { _language = value; } }
}
