using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SnailHealthComponent : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerTracker _tracker;
    [SerializeField] private float _pushFactor = 1.5f;

    public void SetTracker(PlayerTracker t) { _tracker = t; }

    public float PushFactor {  get { return _pushFactor; } set {  _pushFactor = value; } }
    public void GetDamage(float d)
    {
        Transform target = _tracker.GetNearestPlayer(transform.position);
        Vector3 distance = target.position - transform.position;
        distance = distance.normalized;

        Vector2 finalPos = transform.position - (distance * d * PushFactor);
        transform.position = finalPos;
    }
}
