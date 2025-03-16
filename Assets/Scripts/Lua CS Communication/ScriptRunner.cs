using System;
using System.Collections;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using Unity.Collections;
using UnityEditor.PackageManager.UI;
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

        UserData.RegisterType<Vector3>();
        script.Globals["Vector3"] = (Func<float, float, float, Vector3>)((x, y, z) => new Vector3(x, y, z));

        UserData.RegisterType<Quaternion>();
        script.Globals["Quaternion"] = new Table(script);

        script.Globals.Get("Quaternion").Table["Identity"] = Quaternion.identity;
        script.Globals.Get("Quaternion").Table["Euler"] = 
            (Func<float, float, float, Quaternion>)((x, y, z) => Quaternion.Euler(x, y, z));

        script.Globals["GenerateRandomNumber"] = 
            (Func<float, float, float>)((min, max) => GenerateRandomNumber(min, max));
        script.Globals["GenerateRandomInt"] = 
            (Func<int, int, int>)((min, max) => GenerateRandomInt(min, max));
    }

    void Start()
    {
        script.DoString("print('Script Runner started Correctly')");
    }

    private void CustomPrint(DynValue value){
        Debug.Log(value.ToPrintString());
    }

    private float GenerateRandomNumber(float min, float max){
        return UnityEngine.Random.Range(min, max);
    }

    private int GenerateRandomInt(int min, int max){
        return (int) UnityEngine.Random.Range(min, max+1);
    }

    public Script GetScript(){
        return Instance.script;
    }
}
