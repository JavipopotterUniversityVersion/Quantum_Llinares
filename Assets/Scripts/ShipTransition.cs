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
    [SerializeField] UnityEvent _onMerge;
    public UnityEvent OnMerge => _onMerge;

    [SerializeField] Transform _entitiesContainer;
    [SerializeField] float _splitTime = 0.5f;
    [SerializeField] float _mergeTime = 0.5f;
    float _shipDistance;

    UpdatesManager _mainShipUpdatesManager;
    UpdatesManager _ship1UpdatesManager;
    UpdatesManager _ship2UpdatesManager;

    bool _leftIsPressed = false;
    bool _rightIsPressed = false;

    bool _canChange = true;

    private void Awake() {
        _mainShipUpdatesManager = MainShip.GetComponent<UpdatesManager>();
        _ship1UpdatesManager = Ship1.GetComponent<UpdatesManager>();
        _ship2UpdatesManager = Ship2.GetComponent<UpdatesManager>();
    }

    private void Update() {
        if(!divided && _canChange)
        {
            if(_leftIsPressed && _rightIsPressed)
            {
                Divide();
                _onDivide.Invoke();
            }
        }
    }

    public void MergeToRight(InputAction.CallbackContext context){
        if(divided && _canChange)
        {
            //LLamar al manager de updates para que gestione cosas si se encuentra un upgrade en el ship
             ShootComponent[] sC = Ship1.GetComponentsInChildren<ShootComponent>();
            _mainShipUpdatesManager.OnShipMerged(sC);
            StartCoroutine(Merge(Ship2, Ship1.position));
        }
    }

    public void MergeToLeft(InputAction.CallbackContext context){
        if(divided && _canChange)
        {
            //LLamar al manager de updates para que gestione cosas si se encuentra un upgrade en el ship
            ShootComponent[] sC = Ship2.GetComponentsInChildren<ShootComponent>();
            _mainShipUpdatesManager.OnShipMerged(sC);
            StartCoroutine(Merge(Ship1, Ship2.position));
        }
    }

    public void PushLeft(InputAction.CallbackContext context){
        Debug.Log("Izquierda est� de acuerdo");
        _leftIsPressed = context.ReadValue<float>() > 0;
    }

    public void PushRight(InputAction.CallbackContext context){
        Debug.Log("Derecha est� de acuerdo");
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

    void Divide() { 
        _canChange = false;

        Ship1.gameObject.SetActive(true);
        Ship2.gameObject.SetActive(true);
        MainShip.gameObject.SetActive(false);

        Ship1.position = MainShip.position + Vector3.right * _shipDistance;
        Ship2.position = MainShip.position + Vector3.left * _shipDistance;

        _ship1UpdatesManager.OnShipMerged(MainShip.GetComponentsInChildren<ShootComponent>());
        _ship2UpdatesManager.OnShipMerged(MainShip.GetComponentsInChildren<ShootComponent>());

        divided = true;
        _canChange = true;
    }

    IEnumerator Merge(Transform from, Vector2 to){
        _canChange = false;

        _onMerge.Invoke();
        Vector2 fromInitialPosition = from.position;
        for(float i = 0; i < _splitTime; i += Time.deltaTime){
            from.position = Vector2.Lerp(fromInitialPosition, to, i / _splitTime);
            from.localScale = new Vector3(1, 1 - i / _splitTime, 1);
            yield return new WaitForEndOfFrame();
        }

        from.localScale = Vector3.one;
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
        _canChange = true;
    }
}
