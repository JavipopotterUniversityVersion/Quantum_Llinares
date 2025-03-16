using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToUp : MonoBehaviour
{
    private Transform _mTransform;
    // Start is called before the first frame update
    void Start()
    {
        _mTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        float _aTan = _mTransform.up.y/_mTransform.up.x;
        float _aAngle = Mathf.Atan(_aTan);

        _mTransform.eulerAngles = new Vector3(0,0,_aAngle * Mathf.Rad2Deg); // Green axis
    }
}
