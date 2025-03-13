using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TreeEditor;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class ShootComponent : MonoBehaviour
{

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _cooldown = 100.0f;

    [SerializeField] private Vector2 _directionOffset;

    private bool _canShoot = true;
    private Stopwatch _stopwatch = new Stopwatch();

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
            GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            IMovementComponent bulletMovement = bullet.GetComponent<IMovementComponent>();
            if (bulletMovement != null) bulletMovement.SetDirection(transform.up * _directionOffset);

            _stopwatch.Start();
            _canShoot = false;
         }
    }
}
