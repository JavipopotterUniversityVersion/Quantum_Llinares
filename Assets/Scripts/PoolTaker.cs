using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTaker : MonoBehaviour
{
    [SerializeField] PoolHandler _poolHandler;

    public void TakeFromPool(GameObject obj)
    {
        _poolHandler.OnGetFromPool.Invoke(obj, transform.position);
    }
}
