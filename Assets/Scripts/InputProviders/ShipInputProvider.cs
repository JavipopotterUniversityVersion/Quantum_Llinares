using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipInputProvider : MonoBehaviour
{
    [SerializeField] InputActionReference _rotateRight, _rotateLeft, _shootTopCannon, _shootBottomCannon;

    [SerializeField] RotationComponent _shipRotation;
    [SerializeField] ShootComponent _topCannon, _bottomCannon;

    #region Patron ActionReference
    private void OnEnable()
    {
        _rotateRight.action.Enable();
        _rotateLeft.action.Enable();

        _shootTopCannon.action.Enable();
        _shootBottomCannon.action.Enable();
    }

    private void Awake()
    {
        _rotateRight.action.performed += OnRightInputRecieved;
        _rotateLeft.action.performed += OnLefttInputRecieved;

        _shootTopCannon.action.performed += OnShootTopInputRecieved;
        _shootBottomCannon.action.performed += OnShootBottomInputRecieved;
    }

    private void OnDisable()
    {
        _rotateRight.action.performed -= OnRightInputRecieved;
        _rotateLeft.action.performed -= OnLefttInputRecieved;

        _shootTopCannon.action.performed -= OnShootTopInputRecieved;
        _shootBottomCannon.action.performed -= OnShootBottomInputRecieved;
    }

    private void OnDestroy()
    {
        _rotateRight.action.Disable();
        _rotateLeft.action.Disable();

        _shootTopCannon.action.Disable();
        _shootBottomCannon.action.Disable();
    }
    #endregion

    #region actions
    private void OnRightInputRecieved(InputAction.CallbackContext obj) => _shipRotation.RotateObject(true);
    private void OnLefttInputRecieved(InputAction.CallbackContext obj) => _shipRotation.RotateObject(false);

    private void OnShootTopInputRecieved(InputAction.CallbackContext obj) => _topCannon.Shoot();
    private void OnShootBottomInputRecieved(InputAction.CallbackContext obj) => _bottomCannon.Shoot();
    #endregion
}
