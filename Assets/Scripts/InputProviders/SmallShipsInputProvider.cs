using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SmallShipsInputProvider : MonoBehaviour
{
    [SerializeField]
    InputActionReference _leftRotate, _leftShootTop, _leftShootBottom, _leftEntwine;

    [SerializeField]
    InputActionReference _rightRotate, _rightShootTop, _rightShootBottom, _rightEntwine;

    [SerializeField]

    InputActionReference _pause;

    [SerializeField] RotationComponent _leftShipRotation, _rightShipRotation;
    [SerializeField] ShootComponent _leftTopCannon, _leftBottomCannon, _rightTopCannon, _rightBottomCannon;
    [SerializeField] ShipTransition _transitioner;

    [SerializeField] PauseMenuScript _pauseMenu;

    private void OnEnable()
    {
        _leftRotate.action.Enable();
        _leftShootTop.action.Enable();
        _leftShootBottom.action.Enable();
        _leftEntwine.action.Enable();

        _rightRotate.action.Enable();
        _rightShootTop.action.Enable();
        _rightShootBottom.action.Enable();
        _rightEntwine.action.Enable();

        _pause.action.Enable();
    }

    private void Awake()
    {
        _leftRotate.action.performed += OnLeftRotate;
        _leftRotate.action.canceled += OnLeftRotate;
        _leftShootTop.action.performed += OnLeftTopCannon;
        _leftShootBottom.action.performed += OnLeftBottomCannon;
        _leftEntwine.action.performed += _transitioner.MergeToRight;

        _rightRotate.action.performed += OnRightRotate;
        _rightRotate.action.canceled += OnRightRotate;
        _rightShootTop.action.performed += OnRightTopCannon;
        _rightShootBottom.action.performed += OnRightBottomCannon;
        _rightEntwine.action.performed += _transitioner.MergeToLeft;

         _pause.action.canceled += OnPauseMenu;
    }

    private void OnDestroy()
    {
        _leftRotate.action.performed -= OnLeftRotate;
        _leftRotate.action.canceled -= OnLeftRotate;
        _leftShootTop.action.performed -= OnLeftTopCannon;
        _leftShootBottom.action.performed -= OnLeftBottomCannon;
        _leftEntwine.action.performed -= _transitioner.MergeToRight;

        _rightRotate.action.performed -= OnRightRotate;
        _rightRotate.action.canceled -= OnRightRotate;
        _rightShootTop.action.performed -= OnRightTopCannon;
        _rightShootBottom.action.performed -= OnRightBottomCannon;
        _rightEntwine.action.performed -= _transitioner.MergeToLeft;

         _pause.action.canceled += OnPauseMenu;
    }

    private void OnDisable()
    {
        _leftRotate.action.Enable();
        _leftShootTop.action.Enable();
        _leftShootBottom.action.Enable();
        _leftEntwine.action.Enable();

        _rightRotate.action.Disable();
        _rightShootTop.action.Disable();
        _rightShootBottom.action.Disable();
        _rightEntwine.action.Disable();
        
        _pause.action.Disable();
    }

    #region actions
    private void OnRightRotate(InputAction.CallbackContext obj) => _rightShipRotation.setRotation(obj.ReadValue<Vector3>());
    private void OnLeftRotate(InputAction.CallbackContext obj) => _leftShipRotation.setRotation(obj.ReadValue<Vector3>());

    private void OnRightTopCannon(InputAction.CallbackContext obj) => _rightTopCannon.Shoot();
    private void OnRightBottomCannon(InputAction.CallbackContext obj) => _rightBottomCannon.Shoot();
    private void OnLeftTopCannon(InputAction.CallbackContext obj) => _leftTopCannon.Shoot();
    private void OnLeftBottomCannon(InputAction.CallbackContext obj) => _leftBottomCannon.Shoot();

    private void OnPauseMenu(InputAction.CallbackContext obj) => _pauseMenu.TogglePause();
    #endregion
}
