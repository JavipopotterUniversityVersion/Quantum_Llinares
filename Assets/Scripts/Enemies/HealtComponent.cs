using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Events;

public interface IDamageable
{
    void GetDamage(float d);
}

public class HealtComponent : MonoBehaviour, IDamageable
{

    [SerializeField] float _health = 1.0f;
    [SerializeField] UnityEvent _onDeath;
    [SerializeField] UnityEvent _onDamage;
   
    public void SetHealth(float h){ _health = h;}

    public float GetHealth() => _health;

    public void GetDamage(float d){
        _health -=d;

        if(_health<=0) {
            _onDeath.Invoke();
        }
        else _onDamage.Invoke();
    }
}
