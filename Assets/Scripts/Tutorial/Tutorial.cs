using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] String _estoyLoco;
    [SerializeField] StringContainer _container;
    private void Start()
    {
        _container.SetValue(_estoyLoco);
    }
}
