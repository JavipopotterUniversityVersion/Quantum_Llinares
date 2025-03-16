using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPickupChecker : MonoBehaviour
{
    [SerializeField] Tutorial _tutorial;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<VirtualUpgrade>() != null) _tutorial.PowerUpFound();
    }
}
