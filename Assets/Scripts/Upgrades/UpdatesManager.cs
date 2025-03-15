using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatesManager : MonoBehaviour
{

    //Va a pedir el update y lo va a guardar para poder luego pasarlo a la nave ppal
    public void OnShipMerged(ShootComponent[] Updates)
    {
        ShootComponent[] toBeUpdated = this.gameObject.GetComponentsInChildren<ShootComponent>();
        for (int i = 0; i < toBeUpdated.Length; i++)
        {
            toBeUpdated[i].SetBullet(Updates[i].GetBullet());
            toBeUpdated[i].SetCooldown(Updates[i].GetCooldown());
            toBeUpdated[i].SetCooldownFactor(Updates[i].GetCooldownFactor());
            toBeUpdated[i].GetComponent<SpriteRenderer>().sprite = Updates[i].GetBullet().GetComponent<SpriteRenderer>().sprite;
        }
    }
}
