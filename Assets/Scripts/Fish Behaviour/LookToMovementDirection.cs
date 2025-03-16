using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToMovementDirection : MonoBehaviour
{
    private Transform _mTransform;
    private IMovementComponent _mMovComponent;
    // Start is called before the first frame update
    void Start()
    {
        _mTransform = transform;
        _mMovComponent = GetComponent<IMovementComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        float _aTan = _mMovComponent.GetDirection().y/_mMovComponent.GetDirection().x;
        float _aAngle = Mathf.Atan(_aTan);
        _mTransform.eulerAngles = new Vector3(0,0,_aAngle * Mathf.Rad2Deg); // Green axis
    }
}
