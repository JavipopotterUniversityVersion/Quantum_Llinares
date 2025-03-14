using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipInputProvider : MonoBehaviour
{
    [SerializeField] InputActionReference _rotate, _shootTopCannon, _shootBottomCannon, _subdivide1, _subdivide2, _pause;

    [SerializeField] RotationComponent _shipRotation;
    [SerializeField] ShootComponent _topCannon, _bottomCannon;
    [SerializeField] ShipTransition _transitioner;

    [SerializeField] PauseMenuScript _pauseMenu;

    private int _subdivisionAttempts = 0;

    #region Patron ActionReference
    private void OnEnable()
    {
        _rotate.action.Enable();

        _shootTopCannon.action.Enable();
        _shootBottomCannon.action.Enable();

        _subdivide1.action.Enable();
        _subdivide2.action.Enable();

        _pause.action.Enable();
    }

    private void Awake()
    {
        _rotate.action.performed += OnRotationInputRecieved;
        _rotate.action.canceled += OnRotationInputStopped;

        _shootTopCannon.action.performed += OnShootTopInputRecieved;
        _shootBottomCannon.action.performed += OnShootBottomInputRecieved;

        _subdivide1.action.performed += _transitioner.PushLeft;
        _subdivide2.action.performed += _transitioner.PushRight;

        _subdivide1.action.canceled += _transitioner.PushLeft;
        _subdivide2.action.canceled += _transitioner.PushRight;

        _pause.action.canceled += OnPauseMenuInputRecieved;
    }

    private void OnDestroy()
    {
        _rotate.action.performed -= OnRotationInputRecieved;
        _rotate.action.canceled -= OnRotationInputStopped;

        _shootTopCannon.action.performed -= OnShootTopInputRecieved;
        _shootBottomCannon.action.performed -= OnShootBottomInputRecieved;

        _subdivide1.action.performed -= _transitioner.PushLeft;
        _subdivide2.action.performed -= _transitioner.PushRight;

        _subdivide1.action.canceled -= _transitioner.PushLeft;
        _subdivide2.action.canceled -= _transitioner.PushRight;

        _pause.action.canceled -= OnPauseMenuInputRecieved;
    }
    private void OnDisable()
    {
        _rotate.action.Disable();

        _shootTopCannon.action.Disable();
        _shootBottomCannon.action.Disable();

        _subdivide1.action.Disable();
        _subdivide2.action.Disable();
        _pause.action.Disable();
    }

    #endregion

    #region actions
    private void OnRotationInputRecieved(InputAction.CallbackContext obj) => _shipRotation.setRotation(obj.action.ReadValue<Vector3>());
    private void OnRotationInputStopped(InputAction.CallbackContext obj) => _shipRotation.setRotation(Vector3.zero);

    private void OnShootTopInputRecieved(InputAction.CallbackContext obj) => _topCannon.Shoot();
    private void OnShootBottomInputRecieved(InputAction.CallbackContext obj) => _bottomCannon.Shoot();

  
    private void OnPauseMenuInputRecieved(InputAction.CallbackContext obj) => _pauseMenu.TogglePause();
    #endregion
}
