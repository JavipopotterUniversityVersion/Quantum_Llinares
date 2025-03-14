using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VirtualUpgrade : MonoBehaviour
{   
    [SerializeField] private Collider2D _collider2D;

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("a");
        RotationComponent rot = collision.GetComponent<RotationComponent>();
        if(rot!=null){
            ApplyUpgrade(rot.gameObject);
        }
    }
    virtual public void ApplyUpgrade(GameObject obj){
    }
}
