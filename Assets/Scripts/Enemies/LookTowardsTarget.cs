using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LookTowardsTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Transform _mTransform;

    // Start is called before the first frame update
    void Start()
    {
        _mTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _aTargetVector = _target.position - _mTransform.position;
        float _aTan = _aTargetVector.y/_aTargetVector.x;
        float _aAngle = Mathf.Atan(_aTan);

        int _extraAngle = 0;
        if(_mTransform.position.x > 0) _extraAngle = 90;
        else _extraAngle = -90;
        _mTransform.eulerAngles = new Vector3(0,0,_aAngle * Mathf.Rad2Deg + _extraAngle); // Green axis
    }

    public void setTarget(Transform newTarget){
        _target = newTarget;
    }
}
