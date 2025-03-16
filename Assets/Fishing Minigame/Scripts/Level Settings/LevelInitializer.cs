using System;
using System.Collections;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using UnityEngine;

public class LevelInitializer : CSLuaScript
{
    [SerializeField] List<string> _levelCreationMethods;
    [SerializeField] Fishes _fishes;
    void Start()
    {
        _levelCreationMethods.Add("RandomLevel");
        _luaScriptName = "RandomLevel";

        _script = ScriptRunner.Instance.GetScript();

        SetUpLuaVariables();
        if(LoadScriptContent()){
            RunScript();
        }
    }

    override protected void SetUpLuaVariables(){
        _script.Globals["fishes"] = _fishes.getFishesNames();
        _script.Globals["SpawnFish"] = (Action<string, Vector3, Quaternion>)SpawnFish;
    }

    void SpawnFish(string fishName, Vector3 position, Quaternion rotation){
        var fish = _fishes.GetPrefabByName(fishName);

        if(fish != null) Instantiate(fish, position, rotation);
        else Debug.LogError("ERROR couldn't find " + fishName + " prefab");
    }
}
