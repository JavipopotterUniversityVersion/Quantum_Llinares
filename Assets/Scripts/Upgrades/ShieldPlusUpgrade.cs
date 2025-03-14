using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldPlusUpgrade: VirtualUpgrade
{
    override public void ApplyUpgrade(GameObject obj)
    {
        Debug.Log("A");
        ShipHealth h = obj.GetComponent<ShipHealth>();
        int maxShield = h.getMaxShield();
        h.setMaxShield(maxShield+1);
        h.setShieldToMax();
        Destroy(this.gameObject);
    }
}
