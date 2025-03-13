using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] private LayerMask _targetlayer;
    [SerializeField] private float _damage;
    bool _destroyOnHit = true;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if ((_targetlayer & (1 << other.gameObject.layer)) != 0)
        {
            HealtComponent hc = other.gameObject.GetComponent<HealtComponent>();
            if (hc != null)
            {
                if(_destroyOnHit) Destroy(gameObject);
                hc.GetDamage(_damage);
            }
        }
    }

}
