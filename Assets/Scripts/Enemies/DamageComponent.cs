using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageComponent : MonoBehaviour, IDamager
{
    [SerializeField] private LayerMask _targetlayer;
    [SerializeField] private float _damage;
    [SerializeField] bool _destroyOnHit = true;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if ((_targetlayer & (1 << other.gameObject.layer)) != 0)
        {
            IDamageable hc = other.gameObject.GetComponent<IDamageable>();
            if (hc != null)
            {
                if(_destroyOnHit) Destroy(gameObject);
                hc.GetDamage(_damage);
            }
        }
    }
    public float GetDamage() => _damage;

    public void SetDamage(float d){
        _damage = d;
    }

}
