using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _audioClip;

    private void Start()
    {
        _audioSource.playOnAwake = false;
        _audioSource.loop = false;
        _audioSource.volume = AudioManager.Instance.SoundFXVolume;
    }

    public void Warn()
    {
        _animator.SetTrigger("warn");
    }

    public void Shoot()
    {
        _animator.SetTrigger("shoot");
        _audioSource.PlayOneShot(_audioClip);
    }

    public void LaserFinished()
    {
        LaserManager.Instance.LaserFinishedShooting();
    }

}
