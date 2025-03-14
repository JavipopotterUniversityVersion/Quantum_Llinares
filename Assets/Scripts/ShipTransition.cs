using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ShipTransition : MonoBehaviour
{
    private bool divided = false;
    [SerializeField] Transform MainShip;
    [SerializeField] Transform Ship1;
    [SerializeField] Transform Ship2;
    [SerializeField] UnityEvent _onDivide;
    public UnityEvent OnDivide => _onDivide;
    [SerializeField] Transform _entitiesContainer;
    [SerializeField] float _splitTime = 0.5f;
    [SerializeField] float _mergeTime = 0.5f;
    float _shipDistance;

    bool _leftIsPressed = false;
    bool _rightIsPressed = false;

    private void Update() {
        if(!divided)
        {
            if(_leftIsPressed && _rightIsPressed)
            {
                Divide();
                _onDivide.Invoke();
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Merge(Ship2, Ship1.position));
            }
            else if(Input.GetKeyDown(KeyCode.U))
            {
                StartCoroutine(Merge(Ship1, Ship2.position));
            }
        }
    }

    void MergeToRight(InputAction.CallbackContext context){
        if(divided)
        {
            StartCoroutine(Merge(Ship2, Ship1.position));
        }
    }

    void MergeToLeft(InputAction.CallbackContext context){
        if(divided)
        {
            StartCoroutine(Merge(Ship1, Ship2.position));
        }
    }

    void PushLeft(InputAction.CallbackContext context){
        _leftIsPressed = context.ReadValue<float>() > 0;
    }

    void PushRight(InputAction.CallbackContext context){
        _rightIsPressed = context.ReadValue<float>() > 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        _shipDistance = Vector2.Distance(MainShip.position, Ship2.position);
        MainShip.transform.SetParent(_entitiesContainer);
        Ship1.transform.SetParent(_entitiesContainer);
        Ship2.transform.SetParent(_entitiesContainer);
    }

    void Divide(){
        Ship1.gameObject.SetActive(true);
        Ship2.gameObject.SetActive(true);
        MainShip.gameObject.SetActive(false);

        Ship1.position = MainShip.position + Vector3.right * _shipDistance;
        Ship2.position = MainShip.position + Vector3.left * _shipDistance;

        divided = true;
    }

    IEnumerator Merge(Transform from, Vector2 to){
        Vector2 fromInitialPosition = from.position;
        for(float i = 0; i < _splitTime; i += Time.deltaTime){
            from.position = Vector2.Lerp(fromInitialPosition, to, i / _splitTime);
            yield return new WaitForEndOfFrame();
        }

        from.position = to;
        Ship1.gameObject.SetActive(false);
        Ship2.gameObject.SetActive(false);
        MainShip.position = to;

        MainShip.gameObject.SetActive(true);

        Vector2 _entitiesContainerInitialPosition = _entitiesContainer.position;
        Vector2 _targetPos = (Vector2)_entitiesContainer.position - (Vector2)MainShip.position;

        for(float i = 0; i < _mergeTime; i += Time.deltaTime){
            _entitiesContainer.position = Vector2.Lerp(_entitiesContainerInitialPosition, _targetPos, i / _mergeTime);
            yield return new WaitForEndOfFrame();
        }

        divided = false;
    }
}
