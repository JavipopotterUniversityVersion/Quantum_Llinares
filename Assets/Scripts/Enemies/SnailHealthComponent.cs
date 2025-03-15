using UnityEngine;

public class SnailHealthComponent : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerTracker _tracker;
    [SerializeField] private float _pushFactor = 1.0f;

    private void Awake() {
        _tracker = GetComponent<ShipTransitionListener>().GetPlayerTracker();
    }

    public float PushFactor {  get { return _pushFactor; } set {  _pushFactor = value; } }
    public void GetDamage(float d)
    {
        Transform target = _tracker.GetNearestPlayer(transform.position);
        Vector3 distance = target.position - transform.position;
        distance = distance.normalized;

        transform.position += -(distance) * d * _pushFactor;
    }
}
