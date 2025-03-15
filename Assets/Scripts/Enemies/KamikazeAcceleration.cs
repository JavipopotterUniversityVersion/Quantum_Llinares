using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeAcceleration : MonoBehaviour
{FollowMovement followMovement;
    [SerializeField] float acceleration = 0.0075f;

    // Start is called before the first frame update
    void Start()
    {
        followMovement = GetComponent<FollowMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        followMovement.setSpeed(followMovement.getSpeed() + acceleration);
    }
}
