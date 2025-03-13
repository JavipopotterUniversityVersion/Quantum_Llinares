using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LinearMovementComponent : MonoBehaviour, IMovementComponent
{
    Transform _mTransform;
    [SerializeField] float _speed = 10.0f;
    [SerializeField] Vector2 _direction = Vector2.up;

    // Start is called before the first frame update
    void Start()
    {
        _mTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _mTransform.Translate(_direction * _speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 direction) => _direction = direction;
    public Vector2 GetDirection() => _direction;
}
