using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingMovementComponent : MonoBehaviour
{
    Transform myTransform;
    [SerializeField] Transform followRef;
    float speed = 1.5f;
    [SerializeField] float maxOffset = 5;
    [SerializeField] float radius = 5;
    float distanceToTarget;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, radius);
        if(hit.Length > 0)
        {
            bool found = false;
            int index = 0;
            while (!found && index < hit.Length)
            {
                if(hit[index].GetComponent<HealthComponent>())
                {
                    found = true;
                    followRef = hit[index].transform;
                }
                else
                {
                    index++;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
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
