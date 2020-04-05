using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MEC;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private Image _fillImage;
    public float Timer;
    private float _timer;

    [SerializeField] private bool _isLoadingDone;

    private void Start()
    {
        Timing.RunCoroutine(_StartGameSceneCoroutine());
    }
    // Update is called once per frame
    void Update()
    {
        
        if(!_isLoadingDone)
        {
            if(_timer < Timer)
            {
                _timer += Time.deltaTime;
                _fillImage.fillAmount =  _timer / Timer;
            }

            if(_timer >= Timer) _isLoadingDone = true;
        }
    }

    private IEnumerator<float> _StartGameSceneCoroutine()
    {
        yield return Timing.WaitForSeconds(Timer + 1f);
        SceneSwitcher.Instance.LoadMainMenu();
    }
}
