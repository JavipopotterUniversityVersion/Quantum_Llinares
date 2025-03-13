using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TreeEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class ShootComponent : MonoBehaviour
{

    [SerializeField] GameObject _bullet;
    [SerializeField] float _cooldown = 100.0f;

    [SerializeField] Vector2 v;
    Transform _shipTransform;

    bool _canShoot = true;
    Stopwatch _stopwatch = new Stopwatch();
    private void Start()
    {
        _shipTransform = transform;
    }
    private void Update()
    {
        if(!_canShoot){
            if(_stopwatch.ElapsedMilliseconds>= _cooldown) {
                _canShoot = true;
                _stopwatch.Stop();
                _stopwatch.Reset();
            }
        }   
    }
    public void ShootUp(){
    
     if(_canShoot)
     { 
        GameObject.Instantiate(_bullet,v*_shipTransform.up,Quaternion.identity);
        _canShoot = false;
       _stopwatch.Start();
    }
    }
    public void ShootDown(){
    
     if(_canShoot)
     { 
        GameObject.Instantiate(_bullet,v*_shipTransform.up,Quaternion.identity);
        _canShoot = false;
       _stopwatch.Start();
    }
    }
}
