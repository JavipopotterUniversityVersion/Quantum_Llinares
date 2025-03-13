using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipInputProvider : MonoBehaviour
{
    [SerializeField] InputActionReference _rotate, _shootTopCannon, _shootBottomCannon;

    [SerializeField] RotationComponent _shipRotation;
    [SerializeField] ShootComponent _topCannon, _bottomCannon;

    #region Patron ActionReference
    private void OnEnable()
    {
        _rotate.action.Enable();

        _shootTopCannon.action.Enable();
        _shootBottomCannon.action.Enable();
    }

    private void Awake()
    {
        _rotate.action.performed += OnRotationInputRecieved;
        _rotate.action.canceled += OnRotationInputStopped;

        _shootTopCannon.action.performed += OnShootTopInputRecieved;
        _shootBottomCannon.action.performed += OnShootBottomInputRecieved;
    }

    private void OnDisable()
    {
        _rotate.action.performed -= OnRotationInputRecieved;
        _rotate.action.canceled -= OnRotationInputStopped;

        _shootTopCannon.action.performed -= OnShootTopInputRecieved;
        _shootBottomCannon.action.performed -= OnShootBottomInputRecieved;
    }

    private void OnDestroy()
    {
        _rotate.action.Disable();

        _shootTopCannon.action.Disable();
        _shootBottomCannon.action.Disable();
    }
    #endregion

    #region actions
    private void OnRotationInputRecieved(InputAction.CallbackContext obj) => _shipRotation.setRotation(obj.action.ReadValue<Vector3>());
    private void OnRotationInputStopped(InputAction.CallbackContext obj) => _shipRotation.setRotation(Vector3.zero);

    private void OnShootTopInputRecieved(InputAction.CallbackContext obj) => _topCannon.Shoot();
    private void OnShootBottomInputRecieved(InputAction.CallbackContext obj) => _bottomCannon.Shoot();
    #endregion
}
