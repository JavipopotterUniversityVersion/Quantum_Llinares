using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.TryGetComponent(out ShipHealth shipHealth))
        {
            // Debug.Log("Kamikaze hit player");
            shipHealth.GetDamage(1);
            Destroy(gameObject);
        }
    }
}
