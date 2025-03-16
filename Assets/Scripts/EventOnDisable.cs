using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnDisable : MonoBehaviour
{

    [SerializeField] UnityEvent _onDisable;

    public void OnDisable()
    {
        _onDisable.Invoke();
    }
}
