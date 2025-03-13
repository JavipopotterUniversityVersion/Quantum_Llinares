using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementComponent
{
    Vector2 GetDirection();
    void SetDirection(Vector2 direction);
}
