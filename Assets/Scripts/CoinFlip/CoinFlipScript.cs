using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFlipScript : MonoBehaviour
{
    CoinFlipAninComponent _anuim;
    [SerializeField]GameObject _coin;
    void Start()
    {
        _anuim = _coin.GetComponent<CoinFlipAninComponent>();
       
    }
    public bool SurviveCalc()
    {
        int randomNum = Random.Range(1, 3);
        print("coin:"+ randomNum);
        _coin.SetActive(true);
        _anuim.playCoinAnimation(randomNum == 1);
        return randomNum == 1;
    }
}
