using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeComponent : MonoBehaviour
{
    [SerializeField] private LayerMask _targetMask;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out ShipHealth shipHealth))
        {
            shipHealth.GetDamage(1);
            Destroy(gameObject);
        }
    }
}
