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
        StartCoroutine(DamageCoroutine(finalPos));
    }

    private IEnumerator DamageCoroutine(Vector2 finalPos)
    {
        while (true)
        {
            transform.position = Vector2.Lerp(transform.position, finalPos, Time.deltaTime);
            if((transform.position - (Vector3)finalPos).magnitude <= 0.5f) { break; }
        }

        yield return null;
    }
}
