using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class ShipHealth : MonoBehaviour, IDamageable
{
    private Stopwatch _watch = new Stopwatch();
    [SerializeField] private float _recoverShieldInterval = 10000;
    [SerializeField] private bool _shieldAvailable = true;
    [SerializeField] UnityEvent _onGetDamage;
    [SerializeField] UnityEvent _onDeath;

    [SerializeField] private Sprite _withShield, _withoutShield;

    SpriteRenderer _sr;

    private int _currentLife;
    [SerializeField] int _totalLife = 1;

    private int _currentShield;
    [SerializeField] int _totalShield = 1;

    void Start()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        _currentLife = _totalLife;
        _currentLife = _totalShield;

        if(_shieldAvailable && _withShield != null) _sr.sprite = _withShield;
        _watch.Start();
    }
    #region setters
    /// <summary>
    /// Sets the current Life. Ignores the life total
    /// </summary>
    /// <param name="newLife"></param> New Life
    public void setLife(int newLife) => _currentLife = newLife;
    public void setMaxLife(int newLife) => _totalLife = newLife;
    /// <summary>
    /// Sets the current Shield. Ignores the shield total
    /// </summary>
    /// <param name="newShield"></param> New Shield
    public void setShield(int newShield) => _currentShield = newShield;
    public void setMaxShield(int newShield) => _totalShield = newShield;
    #endregion
    #region getters
    public int getLife() {return _currentLife;}
    public int getMaxLife() {return _totalLife;}
    public int getShield() {return _currentShield;}
    public int getMaxShield() {return _totalShield;}
    #endregion
    public void setLifeToMax() => _currentLife = _totalLife;
    public void setShieldToMax() => _currentShield = _totalShield;

    /// <summary>
    /// Used exclusively to add life
    /// </summary>
    /// <param name="extraLife"></param> Life to add
    public void addLife(int extraLife){
        Assert.IsTrue(extraLife >= 0);
        _currentLife += extraLife;
        if(_currentLife > _totalLife) _currentLife = _totalLife;
    }

    /// <summary>
    /// Used exclusively to add shield
    /// </summary>
    /// <param name="extraShield"></param> shield to add
    public void addShield(int extraShield){
        Assert.IsTrue(extraShield >= 0);
        _currentShield += extraShield;
        if(_currentShield > _totalShield) _currentShield = _totalShield;
    }

    /// <summary>
    /// Recovers 1 shield if it's not maxed
    /// </summary>
    /// <returns></returns> returns true if the shield was recovered
    public bool recoverShield(){
        if(_currentShield < _totalShield){
            _currentShield++;
            if(_withShield != null)_sr.sprite = _withShield;
            return true;
        }
        return false;
    }

    public void GetDamage(float d){
        if(_currentShield > 0 && _shieldAvailable) _currentShield--;
        else _currentLife--;

        if(_currentLife <= 0) _onDeath.Invoke();
        else _onGetDamage.Invoke();

        if(_currentShield == 0 && _withoutShield != null) _sr.sprite = _withoutShield;
        else if(_withShield != null) _sr.sprite = _withShield;

        _watch.Restart();
    }

    void Update()
    {
        if(_shieldAvailable && _currentShield < _totalShield && _watch.ElapsedMilliseconds >= _recoverShieldInterval){
            recoverShield();
            _watch.Restart();
        }
    }
}
