using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeComponent : MonoBehaviour
{
    [SerializeField] private LayerMask _targetMask;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((_targetMask & (1 << collision.gameObject.layer)) != 0)
        {
            collision.gameObject.GetComponent<ShipHealth>().takeDamage();
            Destroy(gameObject);
        }
    }
}
