using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PoolHandler", menuName = "PoolHandler", order = 1)]
public class PoolHandler : ScriptableObject
{
    UnityEvent<Vector3, string> _onShowTextEffect = new UnityEvent<Vector3, string>();
    public UnityEvent<Vector3, string> OnShowTextEffect => _onShowTextEffect;

    public UnityEvent<GameObject, Vector3> _onGetFromPool = new UnityEvent<GameObject, Vector3>();
    public UnityEvent<GameObject, Vector3> OnGetFromPool => _onGetFromPool;
}
