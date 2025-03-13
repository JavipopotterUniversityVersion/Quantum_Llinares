using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Events;

public class HealtComponent : MonoBehaviour
{

    [SerializeField] float _health = 1.0f;
    [SerializeField] UnityEvent _onDeath;
    [SerializeField] UnityEvent _onDamage;
   
    public void SetHealth(float h){ _health = h;}

    public float GetHealth() => _health;

    public void GetDamage(float d){
        _health -=d;
        _onDamage.Invoke();
        
        if(_health<=0) {
            _onDeath.Invoke();
        }
    }
    
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
