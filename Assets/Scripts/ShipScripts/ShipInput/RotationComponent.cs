using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationComponent : MonoBehaviour
{
    [SerializeField] float _speed = 2.0f;
    Transform _mTransform;
    Vector3 _rotation;

    private void Start()
    {
        _mTransform = transform;
    }

    public void setRotation(Vector3 newRot)
    {
        _rotation = newRot;
    }

    private void FixedUpdate()
    {
        _mTransform.Rotate(_rotation * _speed);
    }
}
