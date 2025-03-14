using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratedMovement : MonoBehaviour
{
    FollowMovement followMovement;
    [SerializeField] float acceleration = 0.0075f; // Se usa cuando está lejos

    // Deceleración
    float deccelerationInitialSpeed;
    float decceleration; // Se usa cuando está cerca
    float enemyMaxOffset;

    // Start is called before the first frame update
    void Start()
    {
        followMovement = GetComponent<FollowMovement>();
        deccelerationInitialSpeed = followMovement.getSpeed();

        enemyMaxOffset = Random.Range(followMovement.getMaxOffset() - 2f, followMovement.getMaxOffset() + 4.5f);

    }

    // Update is called once per frame
    void Update()
    {
        // Si está más lejos que el doble de la distancia máxima permitida, acelera
        if (followMovement.getDistanceToTarget() > enemyMaxOffset*2)
        {
            followMovement.setSpeed(followMovement.getSpeed() + acceleration);
            deccelerationInitialSpeed = followMovement.getSpeed();

        }
        // Si está más cerca que el doble de la distancia máxima permitida, frena hasta alcanzar la distancia máxima permitida
        else if (followMovement.getDistanceToTarget() > enemyMaxOffset)
        {
            decceleration = - (deccelerationInitialSpeed * deccelerationInitialSpeed) / (2 * enemyMaxOffset);
            followMovement.setSpeed(followMovement.getSpeed() + decceleration * Time.deltaTime);
        }
        else if (followMovement.getDistanceToTarget() < enemyMaxOffset)
        {
            followMovement.setSpeed(-(followMovement.getSpeed() + acceleration));
            deccelerationInitialSpeed = followMovement.getSpeed();
        }
    }
}
