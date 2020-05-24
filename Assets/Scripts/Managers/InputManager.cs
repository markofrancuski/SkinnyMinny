using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void InputReceivedEvent(Direction direction);
    public static event InputReceivedEvent InputReceived;

    [SerializeField]
    private bool _isControllable;

    private void Awake()
    {
        GameManager.StartGameEvent += Control;
        GameManager.EndGameEvent += UnControl;
    }

    private void Start()
    {
        GameManager.Instance.StartGame();
    }
    // Update is called once per frame
    void Update()
    {
        if (!_isControllable) return;

        /*
        #if !UNITY_EDITOR
                CheckTouchInput();
        #elif UNITY_EDITOR
                CheckEditorInput();
        #endif
        */

        CheckEditorInput();
    }

    private void OnDisable()
    {
        GameManager.StartGameEvent -= Control;
        GameManager.EndGameEvent -= UnControl;
    }

    [SerializeField]
    private  Vector2 startPos;
    [SerializeField]
    private Vector2 swipeDirection;
    [SerializeField]
    private float _swipeSensitivity = 0.6f;

    //Mobile support => swipes
    void CheckTouchInput()
    {
        if (Input.touchCount > 0)
        {
            //First touch => First finger that touched the screen.
            Touch touch = Input.GetTouch(0);

            //User start pressing the screen => Retreive the start position.
            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }
            //User is no longer touching the screen => Get the position => Check the direction, 'Swiping'.
            if (touch.phase == TouchPhase.Ended)
            {
                swipeDirection = (touch.position - startPos).normalized;

                if (swipeDirection.x >= _swipeSensitivity)
                {
                    AddMovement(Direction.RIGHT);
                }
                else if (swipeDirection.x <= -_swipeSensitivity)
                {
                    AddMovement(Direction.LEFT);
                }
                else if (swipeDirection.y >= _swipeSensitivity)
                {
                    AddMovement(Direction.UP);
                }
                else if (swipeDirection.y <= -_swipeSensitivity)
                {
                    AddMovement(Direction.DOWN);
                }

            }
        }
    }

    void CheckEditorInput()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) AddMovement(Direction.UP);
        if(Input.GetKeyDown(KeyCode.RightArrow)) AddMovement(Direction.RIGHT);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) AddMovement(Direction.LEFT);
        if (Input.GetKeyDown(KeyCode.DownArrow)) AddMovement(Direction.DOWN);
    }

    private void AddMovement(Direction movement)
    {
        //Debug.Log($"Input received: {movement}");
        InputReceived?.Invoke(movement);
    }

    private void Control() =>_isControllable = true;
    private void UnControl() => _isControllable = false;

}
