using MEC;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadLevel(string name, float waitTime = 0f)
    {
        if (_alreadyWaiting) return;

        Timing.RunCoroutine(_WaitForTimeCoroutine(waitTime, name));
    }

    public void LoadLevel(int index, float waitTime = 0f)
    {
        if (_alreadyWaiting) return;

        Timing.RunCoroutine(_WaitForTimeCoroutine(waitTime, "", index));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
        //AudioManager.Instance.PlayMusic(0);
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene(3);
        AudioManager.Instance.PlayMusic(1);
    }

    private bool _alreadyWaiting;

    private IEnumerator<float> _WaitForTimeCoroutine(float timer, string name = "", int index = -1)
    {
        _alreadyWaiting = true;
        yield return Timing.WaitForSeconds(timer);

        if (name != "") SceneManager.LoadScene(name);
        else SceneManager.LoadScene(index);

        _alreadyWaiting = false;

    }

}
