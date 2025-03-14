using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsHandler : MonoBehaviour
{
    [SerializeField] Int _pointsReference;
    [SerializeField] PoolHandler _poolHandler;

    public void AddPoints(int points)
    {
        _pointsReference.AddValue(points);
        _poolHandler.OnShowTextEffect.Invoke(transform.position, points.ToString());
    }
}
