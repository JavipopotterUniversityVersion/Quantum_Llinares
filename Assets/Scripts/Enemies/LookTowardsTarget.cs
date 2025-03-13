using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        _mTransform.LookAt(_target);
    }

    void setTarget(Transform newTarget){
        _target = newTarget;
    }
}
