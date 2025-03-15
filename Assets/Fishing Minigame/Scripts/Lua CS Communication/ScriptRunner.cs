using System;
using System.Collections;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using UnityEngine;

public class ScriptRunner : MonoBehaviour
{
    private readonly Script script = new();

    public static ScriptRunner Instance {get; private set;}

    private void Awake()
    {
        if(Instance == null) Instance = this;   
        else {Destroy(this); return;}

        DontDestroyOnLoad(gameObject);

        Script.DefaultOptions.DebugPrint = s => Debug.Log(s);
        script.Globals["print"] = (Action<DynValue>)CustomPrint;
    }

    void Start()
    {
        script.DoString("print('Hello from Lua')");
    }

    private void CustomPrint(DynValue value){
        Debug.Log(value.ToPrintString());
    }

    public Script GetScript(){
        return Instance.script;
    }
}
