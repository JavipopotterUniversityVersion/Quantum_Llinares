using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCoolDownUpgrade : VirtualUpgrade
{
    [SerializeField] float CooldownMulti = 1.0f;
     override public void ApplyUpgrade(GameObject obj) {
        ShootComponent sc = obj.GetComponentInChildren<ShootComponent>();
        sc.SetCooldown(sc.GetCooldown()*CooldownMulti);
     }

}
