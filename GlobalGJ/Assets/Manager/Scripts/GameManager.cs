using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

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
        if (!LineManager.instance)
        {
            GameObject LM = new GameObject("LineManager");
            LM.AddComponent<LineManager>();
        }
        if (!PlayerManager.instance)
        {
            GameObject PM = new GameObject("PlayerManager");
            PM.AddComponent<PlayerManager>();
        }
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
            if (Input.GetKeyDown(KeyCode.Space))
                UpdateState(GameState.SETUP);
        }
    }

    public void UpdateState(GameState _state)
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
                SceneManager.LoadScene("EndScreen");
                break;
            default:
                break;
                  
        }
        OnStateChange?.Invoke(_state);
    }

    public void pressStart()
    {
        SceneManager.LoadScene("LevelDesign");
    }

    GameState GetCurrentState()
    {
        return state;
    }
    
}
public enum GameState { MAINMENU, PAUSED, UNPAUSE, SETUP, PLAY, GAMEOVER }