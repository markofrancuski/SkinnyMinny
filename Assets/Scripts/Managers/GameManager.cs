using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MEC;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;
    #endregion

    #region Events Declaration
    public delegate void GameStateEvent();
    public static event GameStateEvent StartGameEvent;
    public static event GameStateEvent EndGameEvent;
    #endregion

    #region Components Declaration
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    #endregion

    #region Variables Declaration
    [SerializeField]
    private int _score;
    public int Score
    {
        get { return _score; }
        private set
        {
            _score = value;
            UpdateScore();
            //Update UI
        }
    }

    #endregion

    #region Unity Methods
    private void Awake()
    {
        Instance = this;
        UpdateScore();
    }
    #endregion

    #region Event Methods

    public void StartGame()
    {
        Debug.Log("STARTED");
        StartGameEvent?.Invoke();
        Timing.RunCoroutine(_StartTicking().CancelWith(gameObject), "TickingCoroutine");
    }

    public void EndGame()
    {
        Timing.KillCoroutines("TickingCoroutine");
        EndGameEvent?.Invoke();
    }

    #endregion

    #region Coroutines
    private IEnumerator<float> _StartTicking()
    {
        while(true)
        {
            yield return Timing.WaitForSeconds(1f);
            Score++;
        }
    }

    #endregion

    #region Helper methods

    private void UpdateScore()
    {
        _scoreText.SetText(_score.ToString());
    }

    #endregion

}
