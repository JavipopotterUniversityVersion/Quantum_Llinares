using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationComponent : MonoBehaviour
{
    [SerializeField] float _rotationOffset = 1.0f;
    Transform _mTransform;
    Vector3 _rotation;

    private void Start()
    {
        _mTransform = transform;
    }

    /// <summary>
    /// Rotates the object rotationOffset towards the setted direction
    /// </summary>
    /// <param name="right"></param> direction of rotation
    public void RotateObject(bool right)
    {
        float _aRotation = right 
                         ? -_rotationOffset 
                         : _rotationOffset;

        _rotation.z = _aRotation; // Done to avoid keyboard speed issues
    }

    private void FixedUpdate()
    {
        _mTransform.Rotate(_rotation);

        _rotation.z = 0.0f;
    }
}
