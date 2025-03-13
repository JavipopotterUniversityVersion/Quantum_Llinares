using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ShootAtFixedInterval : MonoBehaviour
{
    [SerializeField] private ShootComponent _shooter;
    [SerializeField] private float _timeInterval; //miliseconds

    private Stopwatch _stopwatch = new Stopwatch();

    private void Start()
    {
        _stopwatch.Start();
    }

    private void Update()
    {
        if( _stopwatch.ElapsedMilliseconds >= _timeInterval)
        {
            _shooter.Shoot();
            _stopwatch.Restart();
        }
    }
}
