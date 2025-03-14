using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CameraEffectsHandler", menuName = "Camera/CameraEffectsHandler", order = 1)]
public class CameraEffectsHandler : ScriptableObject
{
    UnityEvent _onCameraShake = new UnityEvent();
    public UnityEvent OnCameraShake { get => _onCameraShake; }
    public void ShakeCamera()
    {
        _onCameraShake.Invoke();
    }
}
