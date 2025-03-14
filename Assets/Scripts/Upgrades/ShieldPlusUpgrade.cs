using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShieldPlusUpgrade: VirtualUpgrade
{
    override public void ApplyUpgrade(GameObject obj)
    {
        ShipHealth h = obj.GetComponent<ShipHealth>();
        int maxShield = h.getMaxShield();
        h.setMaxShield(maxShield+1);
        h.setShieldToMax();
    }
}
