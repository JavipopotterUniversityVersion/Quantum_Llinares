using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Bounds")){
            Destroy(gameObject);
        }
    }
}
