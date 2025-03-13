using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratedMovement : MonoBehaviour
{
    FollowMovement followMovement;
    [SerializeField] float acceleration = 0.1f; // Se usa cuando está lejos

    // Deceleración
    float deccelerationInitialSpeed;
    float decceleration; // Se usa cuando está cerca

    // Start is called before the first frame update
    void Start()
    {
        followMovement = GetComponent<FollowMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Distance to target: " + followMovement.getDistanceToTarget() + "/ max offset: " + followMovement.getMaxOffset());
        // Si está más lejos que el doble de la distancia máxima permitida, acelera
        if (followMovement.getDistanceToTarget() > followMovement.getMaxOffset()*2)
        {
            followMovement.setSpeed(followMovement.getSpeed() + acceleration);
            deccelerationInitialSpeed = followMovement.getSpeed();

        }
        // Si está más cerca que el doble de la distancia máxima permitida, frena hasta alcanzar la distancia máxima permitida
        else if (followMovement.getDistanceToTarget() > followMovement.getMaxOffset())
        {
            Debug.Log("Decelerating");
            decceleration = - (deccelerationInitialSpeed * deccelerationInitialSpeed) / (2 * followMovement.getMaxOffset());
            followMovement.setSpeed(followMovement.getSpeed() + decceleration * Time.deltaTime);
        }
    }
}
