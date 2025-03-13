using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] Transform[] _ships;

    public Transform GetNearestPlayer(Vector2 position)
    {
        List<Transform> activeShips = _ships.Where(ship => ship.gameObject.activeSelf).ToList();
        return activeShips.OrderBy(ship => Vector2.Distance(ship.position, position)).First();
    }
}
