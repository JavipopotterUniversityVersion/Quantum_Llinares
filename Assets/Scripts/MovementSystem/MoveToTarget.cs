using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    private Transform _mTransform;
    [SerializeField] Vector3 _targetPoint = new Vector3(0, 0, 0);

    [SerializeField] float _speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        _mTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(_mTransform.position != _targetPoint){
            _mTransform.position = Vector3.MoveTowards(_mTransform.position, _targetPoint, _speed * Time.deltaTime);
        }
    }

    public void SetTarget(Vector2 newTarget){
        _targetPoint = new Vector3(newTarget.x, newTarget.y, 0);
    }

    public bool TargetReached(){
        return _mTransform.position == _targetPoint;
    }
}
