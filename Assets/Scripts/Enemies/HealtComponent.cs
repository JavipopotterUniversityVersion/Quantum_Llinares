using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class HealtComponent : MonoBehaviour
{

    [SerializeField] float _health = 1.0f;
   
    public void SetHealth(float h){ _health = h;}

    public float GetHealth() => _health;

    public void GetDamage(float d){
        _health -=d;
        if(_health<0) {
            Destroy(this.gameObject);
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
