using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraEffectsReceiver : MonoBehaviour
{
    CinemachineVirtualCamera _virtualCamera;
    [SerializeField] CameraEffectsHandler _cameraEffectsHandler;

    [SerializeField] float duration = 0.15f;
    [SerializeField] float amplitude = 1.0f;
    [SerializeField] float frequency = 1.0f;

    private void Awake() {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _cameraEffectsHandler.OnCameraShake.AddListener(ShakeCamera);
    }

    public void ShakeCamera()
    {
        StartCoroutine(ShakeCameraRoutine(duration, amplitude, frequency));
    }

    IEnumerator ShakeCameraRoutine(float duration, float amplitude, float frequency)
    {
        CinemachineBasicMultiChannelPerlin noise = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = frequency;
        yield return new WaitForSeconds(duration);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
    }
}
