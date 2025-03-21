using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Rendering;

public class ChangeBulletUpgrade : VirtualUpgrade
{
    [SerializeField]GameObject _bullet;
    [SerializeField] float _cooldown = 100.0f;
    [SerializeField] Sprite _sprite;
    override public void ApplyUpgrade(GameObject obj) {
        List<ShootComponent> sc = obj.GetComponentsInChildren<ShootComponent>().ToList();
        // sc = sc.Where(canon => canon.GetBullet().name == "NormalBulletPrefab").ToList();
        ShootComponent scp = sc.OrderBy(canon => Vector2.Distance(canon.transform.position, transform.position)).First();
        
        scp.GetComponent<SpriteRenderer>().sprite = _sprite;
        scp.SetBullet(_bullet);
        scp.SetCooldown(_cooldown);
        Destroy(this.gameObject);
    }

}
