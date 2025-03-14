using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Rendering;

public class ChangeBulletUpgrade : VirtualUpgrade
{
    [SerializeField]GameObject _bullet;
    
    override public void ApplyUpgrade(GameObject obj) {
        List<ShootComponent> sc = obj.GetComponentsInChildren<ShootComponent>().ToList();
        sc.OrderBy(canon => Vector2.Distance(canon.transform.position, transform.position)).First().SetBullet(_bullet);
    }

}
