using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TreeEditor;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class ShootComponent : MonoBehaviour
{

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _cooldown = 100.0f;
    [SerializeField] private float _speed = 5.0f;

    [SerializeField] private Vector2 _directionOffset;
    [SerializeField] UnityEvent _onShoot;

    private bool _canShoot = true;
    private Stopwatch _stopwatch = new Stopwatch();

    public void SetBullet(GameObject obj){
        _bulletPrefab = obj;
    }
    public void SetCooldown(float aux){
        _cooldown = aux;
    }
    public float GetCooldown() => _cooldown;


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

    public void Shoot(){
         if(_canShoot)
         { 
            _onShoot.Invoke();
            GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);

            if (bullet.TryGetComponent(out IMovementComponent bulletMovement)){ 
                bulletMovement.SetDirection(transform.up * _directionOffset);
                bulletMovement.SetSpeed(_speed);
            }

            _stopwatch.Start();
            _canShoot = false;
         }
    }
}
