using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAtOppositeSide : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Bounds")){
            print("Out of bounds");
            Vector3 pos = transform.position;
            pos.x *= -0.8f;
            transform.position = pos;
        }
    }
}
