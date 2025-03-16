using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowingMovementComponent : MonoBehaviour
{
    Transform myTransform;
    [SerializeField] Transform followRef;
    float speed = 1.5f;
    [SerializeField] float maxOffset = 5;
    [SerializeField] float radius = 5;
    float distanceToTarget;

    [SerializeField] private GameObject _enemiesContainer;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        //Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, radius);
        //if(hit.Length > 0)
        //{
        //    bool found = false;
        //    int index = 0;
        //    while (!found && index < hit.Length)
        //    {
        //        HealthComponent hc;
        //        if(hit[index].TryGetComponent(out hc))
        //        {
        //            found = true;
        //            followRef = hit[index].transform;
        //        }
        //        else
        //        {
        //            index++;
        //        }
        //    }
        //}

        _enemiesContainer = GameObject.FindGameObjectWithTag("EnemiesContainer");
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    // Update is called once per frame
    void Update()
    {

        if (followRef != null)
        {
            Vector3 direction = (followRef.position - myTransform.position).normalized;
            transform.position = transform.position + direction * speed * Time.deltaTime;

            Debug.Log(direction * speed * Time.deltaTime);
        }
        else
        {
            FindTarget();
            myTransform.position += myTransform.up * speed * Time.deltaTime;
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

    private void FindTarget()
    {
        Transform[] possibleTargets = _enemiesContainer.GetComponentsInChildren<Transform>().Where(enemy => enemy.gameObject != _enemiesContainer).ToArray();
        followRef = possibleTargets.OrderBy(enemy => Vector2.Distance(enemy.position, myTransform.position)).FirstOrDefault();
        
    }
}
