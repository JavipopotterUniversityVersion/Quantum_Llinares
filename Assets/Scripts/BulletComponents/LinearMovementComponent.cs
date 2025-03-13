using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LinearMovementComponent : MonoBehaviour
{
    Transform _mTransform;
    [SerializeField] float _speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        _mTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _mTransform.Translate(_mTransform.up * _speed * Time.deltaTime);
    }
}
