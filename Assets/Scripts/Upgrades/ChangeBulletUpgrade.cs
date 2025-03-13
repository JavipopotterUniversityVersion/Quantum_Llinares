using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ChangeBulletUpgrade : VirtualUpgrade
{
    [SerializeField]GameObject _bullet;
    
    override public void ApplyUpgrade(GameObject obj) {
        ShootComponent sc = obj.GetComponentInChildren<ShootComponent>();
        sc.SetBullet(_bullet);
    }

}
