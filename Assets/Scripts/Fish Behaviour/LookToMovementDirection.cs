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
        _mTransform.up = _mMovComponent.GetDirection();
    }
}
