using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ShipTransitionListener : MonoBehaviour
{
    ShipTransition shipTransition;
    FollowMovement followMovement;
    PlayerTracker playerTracker;
    // Start is called before the first frame update
    void Start()
    {
        followMovement = GetComponent<FollowMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeRef()
    {
        Transform playerRef = playerTracker.GetNearestPlayer(transform.position);
        followMovement.setTarget(playerRef);
    }

    public void OnDisable(){
        shipTransition.OnDivide.RemoveListener(ChangeRef);
    }

    public void setShipTransition(ShipTransition shipTransition_){
        shipTransition = shipTransition_;
        shipTransition.OnDivide.AddListener(ChangeRef);
    }

    public void setPlayerTracker(PlayerTracker playerTracker_){
        playerTracker = playerTracker_;
    }
}