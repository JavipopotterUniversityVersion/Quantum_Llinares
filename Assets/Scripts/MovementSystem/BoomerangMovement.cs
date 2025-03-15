using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangMovement : MonoBehaviour
{
    Transform _mTransform;
    [SerializeField] float _speed = 10.0f;
    float _actualSpeed;
    Vector2 _direction = Vector2.up;
    private float _returnSpeed = 0.075f;

    // Start is called before the first frame update
    void Start()
    {
        _mTransform = transform;
        _actualSpeed = _speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(_actualSpeed > -_speed) _actualSpeed -= _returnSpeed;
        _mTransform.Translate(_direction * _actualSpeed * Time.deltaTime);
    }

    public void SetSpeed(float speed) => _speed = speed;

    public void SetDirection(Vector2 direction) => _direction = direction;
    public Vector2 GetDirection() => _direction;
}
