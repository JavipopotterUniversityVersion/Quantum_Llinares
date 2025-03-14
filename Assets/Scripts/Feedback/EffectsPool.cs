using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EffectsPool : MonoBehaviour
{
    [SerializeField] GameObject _textEffectPrefab;
    [SerializeField] int _textEffectPoolSize = 10;

    Queue<TextMeshPro> _textEffectPool = new Queue<TextMeshPro>();
    [SerializeField] PoolHandler _poolHandler;

    private void Awake() {
        for (int i = 0; i < _textEffectPoolSize; i++)
        {
            TextMeshPro textEffect = Instantiate(_textEffectPrefab, transform).GetComponent<TextMeshPro>();
            _textEffectPool.Enqueue(textEffect);
            textEffect.gameObject.SetActive(false);
        }

        _poolHandler.OnShowTextEffect.AddListener(ShowTextEffect);
    }

    private void OnDestroy() {
        _poolHandler.OnShowTextEffect.RemoveListener(ShowTextEffect);
    }

    public void ShowTextEffect(Vector3 position, string text)
    {
        TextMeshPro textEffect = _textEffectPool.Dequeue();
        textEffect.transform.position = position;
        textEffect.text = text;
        textEffect.gameObject.SetActive(true);
        _textEffectPool.Enqueue(textEffect);
    } 
}
