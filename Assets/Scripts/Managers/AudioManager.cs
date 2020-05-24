using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{

    public delegate void OnSoundValueChange(float value);
    public static event OnSoundValueChange OnSoundChanged;


    [SerializeField]
    private AudioSource _musicSource;

    [SerializeField]
    private AudioSource _soundFXSource;
    [SerializeField]
    private AudioClip _buttonHoverClip;

    [SerializeField]
    private AudioClip[] _musicClips;

    public float SoundFXVolume;
    private bool _isStarted;

    public void DoOnStart()
    {
        //Music
        _musicSource.playOnAwake = true;
        _musicSource.loop = true;

        float musicValue = 1;
        if (PlayerPrefs.HasKey("Music")) musicValue = PlayerPrefs.GetFloat("Music");
        _musicSource.volume = musicValue;
        if (!_isStarted) { PlayMusic(0); _isStarted = true; }


        _soundFXSource.playOnAwake = false;
        _soundFXSource.loop = false;

        SoundFXVolume = 1;
        if (PlayerPrefs.HasKey("Sound")) SoundFXVolume = PlayerPrefs.GetFloat("Sound");
        _soundFXSource.volume = SoundFXVolume;
    }

    public void PlayMusic(int index)
    {
        _musicSource.Stop();
        _musicSource.clip = _musicClips[index];
        _musicSource.Play();
    }

    public void PlaySoundFX(AudioClip clip)
    {
        _soundFXSource.PlayOneShot(clip);
    }

    public void PlayButtonHoverSound()
    {
        _soundFXSource.PlayOneShot(_buttonHoverClip);
    }

    public void UpdateMusicVolume(float newValue)
    {
        _musicSource.volume = newValue;
        PlayerPrefs.SetFloat("Music", newValue);
    }

    public void UpdateSoundVolume(float newValue)
    {
        SoundFXVolume = newValue;
        PlayerPrefs.SetFloat("Sound", newValue);
        _soundFXSource.volume = newValue;
        OnSoundChanged?.Invoke(newValue);
    }


}
