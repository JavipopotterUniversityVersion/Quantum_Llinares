using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisableInTime : MonoBehaviour
{
    [SerializeField] UnityEvent _onEnable;
    [SerializeField] float _disableTime = 0.5f;
    float _timer = 0f;

    private void OnEnable() {
        _onEnable.Invoke();
    }

    private void Update() {
        _timer += Time.deltaTime;
        
        if(_timer >= _disableTime){
            gameObject.SetActive(false);
            _timer = 0f;
        }
    }
}
