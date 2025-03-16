using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class EditorLuaFile : Editor
{
    private static readonly string _defaultLuaCode = "print(\"Esto es un script de Lua\")";

    [MenuItem("Assets/Create/Lua Script", false, 80)]
    public static void CreateLuaScript(){
        var folderPath = "Assets";
        if(Selection.activeObject != null && AssetDatabase.Contains(Selection.activeObject)){
            folderPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            if(!AssetDatabase.IsValidFolder(folderPath)) folderPath = Path.GetDirectoryName(folderPath);
        }

        var fullPath = AssetDatabase.GenerateUniqueAssetPath(folderPath + "/NewLuaScript.lua");

        File.WriteAllText(fullPath, _defaultLuaCode);
        AssetDatabase.Refresh();
        var obj = AssetDatabase.LoadAssetAtPath<Object>(fullPath);
        Selection.activeObject = obj;
        EditorGUIUtility.PingObject(obj);
        EditorUtility.FocusProjectWindow();
        EditorGUIUtility.PingObject(obj);
    }
}
