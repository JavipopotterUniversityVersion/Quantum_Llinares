using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField] LayerMask _targetMask;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((_targetMask & (1 << collision.gameObject.layer)) != 0)
        {
            Destroy(gameObject);
        }
    }
}
