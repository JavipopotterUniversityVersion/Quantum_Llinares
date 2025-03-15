using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOffset : MonoBehaviour
{
    [SerializeField] private Vector2 _offset = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3(_offset.x, _offset.y, 0);
    }
}
