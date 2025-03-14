using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GradientAndLerp : MonoBehaviour
{
    [SerializeField] Gradient _gradient;
    [SerializeField] float _duration = 1.0f;
    [SerializeField] float _speed = 1.0f;
    [SerializeField] TextMeshPro _text;

    private void Awake() {
        _text = GetComponent<TextMeshPro>();
    }

    private void OnEnable() {
        StartCoroutine(Appear());
    }

    IEnumerator Appear()
    {
        float timer = 0.0f;
        while(timer < _duration)
        {
            timer += Time.deltaTime;
            _text.color = _gradient.Evaluate(timer / _duration);
            transform.position +=  _speed * Time.deltaTime * Vector3.up;
            yield return new WaitForEndOfFrame();
        }
        gameObject.SetActive(false);
    }
}
