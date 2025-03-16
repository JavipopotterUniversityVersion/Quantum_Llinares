using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFlipAninComponent : MonoBehaviour
{

    [SerializeField] Animator _coin;

    void Start()
    {
        playCoinAnimation(true);
    }
    public void playCoinAnimation(bool t){
        if(!t){
            _coin.Play("coinbad");
        }
        else _coin.Play("coingood");
    }
    public void StartAnimation()
    {
         //Time.timeScale = 0.0f;
    }
    public void EndAnimation()
    {
        this.gameObject.SetActive(false);
        // Time.timeScale = 1.0f;
        
    }
}
