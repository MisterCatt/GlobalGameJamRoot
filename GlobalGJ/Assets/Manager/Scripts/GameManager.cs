using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    
    [SerializeField]
    GameState state;
    GameState previousState;

    public static event Action<GameState> OnStateChange;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {

            instance = this;
        }
    }

    private void Start()
    {
        UpdateState(GameState.MAINMENU);
    }

    private void Update()
    {
        if (state == GameState.PAUSED)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                UpdateState(GameState.UNPAUSE);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                UpdateState(GameState.PAUSED);
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                UpdateState(GameState.MAINMENU);
            }
        }
    }

    void UpdateState(GameState _state)
    {
        previousState = this.state;
        this.state = _state;

        switch (_state)
        {
            case GameState.MAINMENU:
                break;
            case GameState.PAUSED:
                Time.timeScale = 0f;
                break;
            case GameState.UNPAUSE:
                Time.timeScale = 1f;
                break;
            case GameState.SETUP:
                break;
            case GameState.PLAY:
                break;
            case GameState.GAMEOVER:
                break;
            default:
                break;
                  
        }
        OnStateChange?.Invoke(_state);
    }

    GameState GetCurrentState()
    {
        return state;
    }
    
}
public enum GameState { MAINMENU, PAUSED, UNPAUSE, SETUP, PLAY, GAMEOVER }