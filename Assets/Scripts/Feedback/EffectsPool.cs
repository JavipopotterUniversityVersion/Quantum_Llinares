using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EffectsPool : MonoBehaviour
{
    [System.Serializable]
    class PoolObject
    {
        public int size = 10;
        public Queue<GameObject> pool = new Queue<GameObject>();
    }

    [SerializeField] GameObject _textEffectPrefab;
    [SerializeField] int _textEffectPoolSize = 10;
    Queue<TextMeshPro> _textEffectPool = new Queue<TextMeshPro>();

    [SerializeField] SerializableDictionary<GameObject, PoolObject> _poolObjects;

    [SerializeField] PoolHandler _poolHandler;

    private void Awake() {
        for (int i = 0; i < _textEffectPoolSize; i++)
        {
            TextMeshPro textEffect = Instantiate(_textEffectPrefab, transform).GetComponent<TextMeshPro>();
            _textEffectPool.Enqueue(textEffect);
            textEffect.gameObject.SetActive(false);
        }

        foreach(KeyValuePair<GameObject, PoolObject> entry in _poolObjects)
        {
            PoolObject poolObject = entry.Value;
            for (int i = 0; i < poolObject.size; i++)
            {
                GameObject obj = Instantiate(entry.Key, transform);
                poolObject.pool.Enqueue(obj);
                obj.SetActive(false);
            }
            _poolObjects[entry.Key] = poolObject;
        }

        _poolHandler.OnShowTextEffect.AddListener(ShowTextEffect);
        _poolHandler.OnGetFromPool.AddListener(GetFromPool);
    }

    public void GetFromPool(GameObject obj, Vector3 position)
    {
        PoolObject poolObject = _poolObjects[obj];
        GameObject pooledObject = poolObject.pool.Dequeue();
        pooledObject.transform.position = position;
        pooledObject.SetActive(true);
        poolObject.pool.Enqueue(pooledObject);
    }

    private void OnDestroy() {
        _poolHandler.OnShowTextEffect.RemoveListener(ShowTextEffect);
        _poolHandler.OnGetFromPool.RemoveListener(GetFromPool);
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
