using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class ShootComponent : MonoBehaviour
{

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _cooldown = 100.0f;
    [SerializeField] private float _cooldownfactor = 1.0f;

    [SerializeField] private float damagefactor = 1;

    private float actbulletdamage = 10.0f;
    private float _actCooldown = 100.0f;
    [SerializeField] private float _speed = 5.0f;

    [SerializeField] private Vector2 _directionOffset;
    [SerializeField] UnityEvent _onShoot;

    private bool _canShoot = true;
    private Stopwatch _stopwatch = new Stopwatch();

    [SerializeField] private AudioPlayer _shoot;
    private void Start()
    {
        SetBulletAudio();
        _actCooldown = _cooldown*_cooldownfactor;
    }
    public void SetBullet(GameObject obj){
        _bulletPrefab = obj;
        damagefactor += 0.1f;
        actbulletdamage = obj.GetComponent<IDamager>().GetDamage()* damagefactor;
        SetBulletAudio();
    }
    public void SetBulletAudio()
    {
        _shoot = _bulletPrefab.GetComponent<BulletSound>().getAudio();
    }
    public void SetCooldown(float aux){
        _cooldown = aux;
        _actCooldown = _cooldown*_cooldownfactor;
    }
    public float GetCooldown() => _cooldown;
    public GameObject GetBullet() { return _bulletPrefab; }
    public void SetCooldownFactor(float aux){
        _cooldownfactor = aux;
        _actCooldown = _cooldown*_cooldownfactor;
    }
    public float GetCooldownFactor() => _cooldownfactor;

    private void Update()
    {
        if(!_canShoot){
            if(_stopwatch.ElapsedMilliseconds>= _actCooldown) {
                _canShoot = true;
                _stopwatch.Stop();
                _stopwatch.Reset();
            }
        }   
    }
    public void PlayBulletAudio()
    {
        if(_shoot != null)
        {
            _shoot.Play();
        }
    }
    public void Shoot(){
         if(_canShoot)
         { 
            _onShoot.Invoke();
            PlayBulletAudio();
            GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);

            if (bullet.GetComponent<BoomerangMovement>() != null){
                bullet.GetComponent<BoomerangMovement>().SetDirection(transform.up);
            }
            else

            if (bullet.TryGetComponent(out IMovementComponent bulletMovement)){ 
                _directionOffset += new Vector2(UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(-0.1f, 0.1f));
                bulletMovement.SetDirection(transform.up * _directionOffset);
                bulletMovement.SetSpeed(_speed);
            }
            else if(bullet.TryGetComponent<FadeWithTime>(out FadeWithTime fadeWithTime)) bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<IDamager>().SetDamage(actbulletdamage * damagefactor);
            _stopwatch.Start();
            _canShoot = false;
         }
    }
}
