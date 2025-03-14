using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCoolDownUpgrade : VirtualUpgrade
{
    [SerializeField] float CooldownReduce = 1.0f;
    override public void ApplyUpgrade(GameObject obj)
    {
        ShootComponent sc = obj.GetComponentInChildren<ShootComponent>();
        sc.SetCooldownFactor(sc.GetCooldownFactor() * CooldownReduce);
        Destroy(this.gameObject);
    }

}
