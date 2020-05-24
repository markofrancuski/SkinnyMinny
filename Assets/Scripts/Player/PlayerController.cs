using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class PlayerController : MonoBehaviour
{

    #region Components
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    #endregion

    [SerializeField] private AudioClip _jumpAudioClip;

    [SerializeField]
    private float _moveStep = 0.25f;
    [SerializeField]
    private float _tweenDuration = 0.1f;

    private Vector2 _initialPos;
    private Vector2 _upVector;
    private Vector2 _downVector;
    private Vector2 _rightVector;
    private Vector2 _leftVector;

    private void Awake()
    {
        InputManager.InputReceived += SwipeReceived;
    }
    private void Start()
    {
        _initialPos = transform.position;

        _upVector = new Vector2(0, _moveStep);
        _downVector = new Vector2(0, - _moveStep);
        _rightVector = new Vector2(_moveStep, 0);
        _leftVector = new Vector2(- _moveStep, 0);

        _audioSource.playOnAwake = false;
        _audioSource.loop = false;
        _audioSource.volume = AudioManager.Instance.SoundFXVolume;
    }

    private void OnDisable()
    {
        InputManager.InputReceived -= SwipeReceived;
    }

    [SerializeField]
    private Direction _directionToMove;

    private void SwipeReceived(Direction dir)
    {
        if (_directionToMove != Direction.NONE) return;

        _directionToMove = dir;
        Tween.Position(transform, transform.position, GetPosition(_directionToMove), _tweenDuration, 0, null, Tween.LoopType.None, null, TweenFinished, true);

        _audioSource.PlayOneShot(_jumpAudioClip);
        PlayerMoveAnimation(dir);
    }

    private void TweenFinished()
    {
        Tween.Position(transform, transform.position, GetPosition(Direction.NONE), _tweenDuration, 0, null, Tween.LoopType.None, null, BackToStartPosition, true);
       // if(_directionToMove == Direction.DOWN || _directionToMove == Direction.UP) PlayerMoveAnimation(_directionToMove);
    }

    private void BackToStartPosition()
    {
        _animator.SetTrigger("FinishAnim");
        _directionToMove = Direction.NONE;
    }

    private void PlayerMoveAnimation(Direction dir)
    {
        switch (dir)
        {
            case Direction.NONE:
                
                break;
            case Direction.UP:
                _animator.SetTrigger("Up");
                break;
            case Direction.RIGHT:
                _animator.SetTrigger("Right");
                break;
            case Direction.DOWN:
                _animator.SetTrigger("Down");
                break;
            case Direction.LEFT:
                _animator.SetTrigger("Left");
                break;
            default:
                break;
        }
    }

    private Vector3 GetPosition(Direction dir)
    {
        switch (dir)
        {
            case Direction.NONE:
                return _initialPos;
            case Direction.UP:
                return transform.position + (Vector3) _upVector;
            case Direction.RIGHT:
                return transform.position + (Vector3)_rightVector;
            case Direction.DOWN:
                return transform.position + (Vector3)_downVector;
            case Direction.LEFT:
                return transform.position + (Vector3)_leftVector;
            default:
                return _initialPos;
        }

    }

}
