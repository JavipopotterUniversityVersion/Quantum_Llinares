using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivebarComponent : MonoBehaviour
{
    Transform _mtransform;
    HealtComponent hc;
    float _iniSize;
    float inihealth;
    // Start is called before the first frame update
    void Start()
    {
        _mtransform = GetComponent<Transform>();
        _iniSize = _mtransform.localScale.x;
        hc = GetComponentInParent<HealtComponent>();
        inihealth =hc.GetHealth();
    }
    public void ChangeBar(){
        //print("entro"+_iniSize);
       Vector3 aux = _mtransform.localScale;
       aux.x = (_iniSize*(hc.GetHealth()/inihealth));
       _mtransform.localScale = aux;
    }

}
