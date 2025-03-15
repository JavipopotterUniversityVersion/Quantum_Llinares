using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeWithTime : MonoBehaviour
{
    [SerializeField] private float _time = 3.0f;
    private SpriteRenderer _sr;
    private float _timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        Color _aColor = _sr.color;
        _aColor.a = 1 - (_timer/_time);
        _sr.color = _aColor;

        if(_sr.color.a <= 0) Destroy(gameObject);
    }
}
