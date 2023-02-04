using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{

    void LOGTHIS()
    {
        Debug.Log("MAIN MENU");
    }

    bool isDrawing = false;
    Vector3 startPos, drawPos;

    GameObject lineObject;

    void GameManagerOnStateChange(GameState _state)
    {
        switch (_state)
        {
            case GameState.MAINMENU:
                Debug.Log("MAIN MENU");
                break;
            case GameState.PAUSED:
                Debug.Log("PAUSED");
                break;
            case GameState.UNPAUSE:
                Debug.Log("UNPAUSE");
                break;
            case GameState.SETUP:
                Debug.Log("SETUP");
                break;
            case GameState.PLAY:
                Debug.Log("PLAY");
                break;
            case GameState.GAMEOVER:
                Debug.Log("GAME OVER");
                break;
            default:
                break;
        }

    }

    private void Awake()
    {
        GameManager.OnStateChange += GameManagerOnStateChange;
        
    }

    private void OnDestroy()
    {
        GameManager.OnStateChange -= GameManagerOnStateChange;
    }

    private void Start()
    {
        lineObject = GameObject.Find("LineDrawer");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject line = new GameObject();
            line.AddComponent<LineRenderer>();

            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            line.GetComponent<LineRenderer>().SetPosition(0, new Vector3 (startPos.x, startPos.y, 0));
            lineObject = line;
            isDrawing = true;
        }

        if (isDrawing)
        {
            drawPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            {
                Debug.Log(drawPos.x);
                Debug.Log(drawPos.y);
            }

            lineObject.GetComponent<LineRenderer>().SetPosition(1, new Vector3(drawPos.x, drawPos.y, 0));
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
        }
    }
}
