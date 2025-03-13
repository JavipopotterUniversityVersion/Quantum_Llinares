using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ShootAtRandomInterval : MonoBehaviour
{
    [SerializeField] private ShootComponent _shooter;
    [SerializeField] private float _minTime, _maxTIme; //miliseconds

    private float _interval;

    private Stopwatch _stopwatch = new Stopwatch();

    private void Start()
    {
        _stopwatch.Start();
        _interval = Random.Range(_minTime, _maxTIme);

    }

    private void Update()
    {
        if (_stopwatch.ElapsedMilliseconds >= _interval)
        {
            _shooter.Shoot();
            _stopwatch.Restart();
            _interval = Random.Range(_minTime, _maxTIme);
        }
    }
}
