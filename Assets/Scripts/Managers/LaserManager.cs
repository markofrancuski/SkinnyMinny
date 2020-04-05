using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public class LaserManager : MonoBehaviour
{
    public static LaserManager Instance;

    [SerializeField]
    private Laser[] Lasers;
    [SerializeField]
    private int _laserIndex;

    [SerializeField]
    private float _waitTime;

    protected float WaitTime;
    [SerializeField]
    private float _minWaitTime;
    [SerializeField]
    private float _maxWaitTime;

    [SerializeField]
    private bool _isDone;

    #region Unity methods

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        GameManager.StartGameEvent += StartGame;
        GameManager.EndGameEvent += EndGame;

    }

    private void OnDisable()
    {
        GameManager.StartGameEvent -= StartGame;
        GameManager.EndGameEvent -= EndGame;
    }

    #endregion

    private void StartGame()
    {
        _isDone = true;
        Timing.RunCoroutine(_LaserActivatorCoroutine().CancelWith(this.gameObject), "LaserCoroutine");
    }

    private void EndGame() => Timing.KillCoroutines("LaserCoroutine");

    [SerializeField]
    private float _warnTimer;
    private IEnumerator<float> _LaserActivatorCoroutine()
    {
        while (true)
        {
            while (!_isDone) yield return Timing.WaitForOneFrame;

            _isDone = false;

            //Timers
            _warnTimer = _waitTime / 3;
            _waitTime -= _warnTimer;

            //Wait for third of the wait time to trigger
            yield return Timing.WaitForSeconds(_warnTimer);
            WarnLaser();

            //Wait for the rest of the timer
            yield return Timing.WaitForSeconds(_waitTime);
            ShootLaser();

            //Shoot Laser
        }


    }

    private void WarnLaser()
    {
        Lasers[_laserIndex].Warn();
    }
    private void ShootLaser()
    {
        Lasers[_laserIndex].Shoot();
    }

    public void LaserFinishedShooting()
    {
        _waitTime = Random.Range(_minWaitTime, _maxWaitTime);
        _laserIndex = Random.Range(0, Lasers.Length);
        _isDone = true;
    }


}
