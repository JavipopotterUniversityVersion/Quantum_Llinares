using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFlipAninComponent : MonoBehaviour
{
    [SerializeField] Animation _bad;
    [SerializeField] Animation _good;
    public void playCoinAnimation(bool t){
        if(t){
            _good.Play();
        }
        else _bad.Play();
    }
}
