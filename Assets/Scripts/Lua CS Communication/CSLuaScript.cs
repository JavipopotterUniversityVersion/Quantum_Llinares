using System.Collections;
using System.Collections.Generic;
using System.IO;
using MoonSharp.Interpreter;
using UnityEngine;

public class CSLuaScript : MonoBehaviour
{
    
    [SerializeField]
    protected string _luaScriptName = "Null";
    protected string _luaScriptContent;
    protected Script _script;
    protected bool LoadScriptContent(){
        string path = Path.Combine(Application.streamingAssetsPath, _luaScriptName + ".lua");
        if(File.Exists(path)){
            _luaScriptContent = File.ReadAllText(path);
            Debug.Log("Loaded Lua Script: " + _luaScriptName);
            return true;
        }

        Debug.LogError("ERROR Loading Lua Script: " + _luaScriptName);
        return false;
    }
    protected void RunScript(){
        _script.DoString(_luaScriptContent);
    }

    protected virtual void SetUpLuaVariables(){}
    protected void SetLuaScriptName(string fileName) => _luaScriptName = fileName;
}
