using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishesInitializer : MonoBehaviour
{
    [SerializeField] Fishes _fishesSO;
    // Start is called before the first frame update
    void Awake()
    {
        _fishesSO.Init();
    }
}
