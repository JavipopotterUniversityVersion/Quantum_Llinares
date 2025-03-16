using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fishes", menuName = "Project/Fishes", order = 1)]
public class Fishes : ScriptableObject
{
    [SerializeField]
    private List<GameObject> _fishes = new();

    private readonly List<string> _fishNames = new();
    private Dictionary<string, GameObject> _fishDict;

    public List<string> getFishesNames() => _fishNames;
    public Dictionary<string, GameObject> getFishDict() => _fishDict;

    void OnEnable()
    {
        _fishDict = new Dictionary<string, GameObject>();
        foreach(var fish in _fishes){
            _fishNames.Add(fish.name);
            _fishDict.Add(fish.name, fish);
        }
    }

    public GameObject GetPrefabByName(string name){
        return _fishDict.GetValueOrDefault(name);
    }
}

