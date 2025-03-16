using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSound : MonoBehaviour
{
    [SerializeField] AudioPlayer _bulletSound;
    public AudioPlayer getAudio()
    {
        return _bulletSound;
    }
}
