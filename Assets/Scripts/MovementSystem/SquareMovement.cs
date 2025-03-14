using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SquareMovement : MonoBehaviour
{
    [SerializeField] private float _distanceToCenter = 4;
    private Transform _mTransform;
    private MoveToTarget _mMoveToTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        _mTransform = transform;
        // ! Move to target is needed
        Assert.IsTrue(TryGetComponent<MoveToTarget>(out _mMoveToTarget));
        _mMoveToTarget.SetTarget(new Vector2(_distanceToCenter, _distanceToCenter));
    }

    // Update is called once per frame
    void Update()
    {
        if(_mMoveToTarget.TargetReached()){
            if(_mTransform.position.x == _distanceToCenter){
                if(_mTransform.position.y == _distanceToCenter) _mMoveToTarget.SetTarget(new Vector2(_distanceToCenter, -_distanceToCenter));
                else _mMoveToTarget.SetTarget(new Vector2(-_distanceToCenter, -_distanceToCenter));
            }
            else{
                if(_mTransform.position.y == _distanceToCenter) _mMoveToTarget.SetTarget(new Vector2(_distanceToCenter, _distanceToCenter));
                else _mMoveToTarget.SetTarget(new Vector2(-_distanceToCenter, _distanceToCenter));
            }
        }
    }
}
