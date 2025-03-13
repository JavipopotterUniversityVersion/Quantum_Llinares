using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] private LayerMask _targetlayer;
    [SerializeField] private float _damage;
    private Collider2D _collider;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if ((_targetlayer & (1 << other.gameObject.layer)) != 0)
        {
            HealtComponent hc = other.gameObject.GetComponent<HealtComponent>();
            if (hc != null)
            {
                hc.GetDamage(_damage);
            }
        }
    }

}
