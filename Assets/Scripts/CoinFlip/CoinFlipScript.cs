using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFlipScript : MonoBehaviour
{
    public bool SurviveCalc()
    {
        int randomNum = Random.Range(1, 3);
        return randomNum == 1;
    }
}
