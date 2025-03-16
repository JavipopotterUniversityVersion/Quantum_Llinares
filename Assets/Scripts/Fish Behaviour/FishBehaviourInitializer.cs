using System;
using System.Collections;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using UnityEngine;

public class FishBehaviourInitializer : CSLuaScript
{
    [SerializeField] List<string> _behaviours;
    MoveToTarget _mMoveToTarget;

    // Start is called before the first frame update
       void Start()
    {
        _mMoveToTarget = GetComponent<MoveToTarget>();

        _script = ScriptRunner.Instance.GetScript();

    }

    void Update()
    {
        for(int i = 0; i < _behaviours.Count; ++i){
            
            SetLuaScriptName(_behaviours[i]);

            SetUpLuaVariables();
            if(LoadScriptContent()){
                RunScript();
            }
        }
    }

    override protected void SetUpLuaVariables(){
        _script.Globals["SetTarget"] = (Action<Vector2>)_mMoveToTarget.SetTarget;
        _script.Globals["TargetReached"] = (Func<bool>)_mMoveToTarget.TargetReached;
    }
}
