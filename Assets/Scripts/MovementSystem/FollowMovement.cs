using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : MonoBehaviour
{
    Transform myTransform;
    [SerializeField] Transform followRef;
    [SerializeField] float speed;
    [SerializeField] float maxOffset;
    float distanceToTarget;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector2.Distance(myTransform.position, followRef.position);

        if (followRef != null && distanceToTarget > maxOffset)
        {
            myTransform.position = Vector2.MoveTowards(myTransform.position, followRef.position, speed * Time.deltaTime);
        }
    }

    public void setTarget(Transform target)
    {
        followRef = target;
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public float getDistanceToTarget()
    {
        return distanceToTarget;
    }

    public float getMaxOffset()
    {
        return maxOffset;
    }

    public float getSpeed()
    {
        return speed;
    }
}
