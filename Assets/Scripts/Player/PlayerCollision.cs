using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _dieAudioClip;

    private void Start()
    {
        _audioSource.playOnAwake = false;
        _audioSource.loop = false;
        _audioSource.volume = AudioManager.Instance.SoundFXVolume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Laser"))
        {
            _audioSource.PlayOneShot(_dieAudioClip);
            GameManager.Instance.EndGame();
        }
    }


}
