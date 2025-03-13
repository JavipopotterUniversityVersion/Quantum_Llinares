using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipTransition : MonoBehaviour
{
    private bool divided = false;
    [SerializeField] Transform MainShip;
    [SerializeField] Transform Ship1;
    [SerializeField] Transform Ship2;
    [SerializeField] UnityEvent _onDivide;
    public UnityEvent OnDivide => _onDivide;
    // Start is called before the first frame update
    void Start()
    {
        Divide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Divide")]
    void Divide(){
        _onDivide.Invoke();
        if (divided){
            Ship1.gameObject.SetActive(false);
            Ship2.gameObject.SetActive(false);
            MainShip.gameObject.SetActive(true);
            divided = false;
        }
        else{
            Ship1.gameObject.SetActive(true);
            Ship2.gameObject.SetActive(true);
            MainShip.gameObject.SetActive(false);
            divided = true;
        }
    }
}
