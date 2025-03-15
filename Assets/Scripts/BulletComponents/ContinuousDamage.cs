using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ContinuousDamage : MonoBehaviour, IDamager
{
    [SerializeField] private float _continuousDamage = 0.01f;
    [SerializeField] private LayerMask _targetlayer;

    void OnTriggerStay2D(Collider2D collision)
    {
        if ((_targetlayer & (1 << collision.gameObject.layer)) != 0){
            IDamageable otherHealth = collision.GetComponent<IDamageable>();
            otherHealth.GetDamage(_continuousDamage);
        }
    }

    public float GetDamage() {return _continuousDamage;}
    public void SetDamage(float d) => _continuousDamage = d;
}
