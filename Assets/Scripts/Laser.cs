using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    public void Warn()
    {
        _animator.SetTrigger("warn");
    }

    public void Shoot()
    {
        _animator.SetTrigger("shoot");
 
    }

    public void LaserFinished()
    {
        LaserManager.Instance.LaserFinishedShooting();
    }

}
