using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField] LayerMask _targetMask;
    [SerializeField] UnityEvent _onDestroy;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((_targetMask & (1 << collision.gameObject.layer)) != 0)
        {
            _onDestroy.Invoke();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
