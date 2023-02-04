using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLine : MonoBehaviour
{
    bool isDrawing = false;
    Player pScript;

    float drawDistance = 0;

    GameObject lineObject;
    [SerializeField]
    GameObject[] lines;

    private void Start()
    {
        pScript = GetComponent<Player>();
    }

    private void Update()
    {
        if (!pScript.player2)
            DrawLine(KeyCode.Comma, 0, PlayerManager.instance.birdCanDraw);
        else
            DrawLine(KeyCode.F, 1, PlayerManager.instance.frogCanDraw);
    }

    void DrawLine(KeyCode keyCode, int _playerNumber, bool canDraw)
    {
        if (Input.GetKeyDown(keyCode) && canDraw)
        {
            GameObject line = new GameObject("Line");
            line.AddComponent<LineRenderer>();

            line.GetComponent<LineRenderer>().startWidth = lines[_playerNumber].GetComponent<LineRenderer>().startWidth;
            line.GetComponent<LineRenderer>().material = lines[_playerNumber].GetComponent<LineRenderer>().sharedMaterial;

            line.GetComponent<LineRenderer>().SetPosition(0, new Vector3(transform.position.x, transform.position.y, 0));
            lineObject = line;
            isDrawing = true;
        }

        if (isDrawing)
        {
            if (_playerNumber == 0) {
                if (drawDistance < PlayerManager.instance.birdLinePoints)
                {
                    lineObject.GetComponent<LineRenderer>().SetPosition(1, new Vector3(transform.position.x, transform.position.y, 0));
                    PlayerManager.instance.birdLinePoints -= PlayerManager.instance.linePointMultiplier;
                }
            }
            else
            {
                if (drawDistance < PlayerManager.instance.frogLinePoints)
                {
                    lineObject.GetComponent<LineRenderer>().SetPosition(1, new Vector3(transform.position.x, transform.position.y, 0));
                    PlayerManager.instance.frogLinePoints -= PlayerManager.instance.linePointMultiplier;
                }
            }
        }

        if (Input.GetKeyUp(keyCode))
        {
            if (_playerNumber == 0)
            {
                PlayerManager.instance.birdLinePoints -= drawDistance;
            }
            else
            {
                PlayerManager.instance.frogLinePoints -= drawDistance;
            }

            if(PlayerManager.instance.birdLinePoints < 0)
            {
                PlayerManager.instance.birdLinePoints = 0;
            }

            if(PlayerManager.instance.frogLinePoints < 0)
            {
                PlayerManager.instance.frogLinePoints = 0;
            }

            isDrawing = false;

        }
    }
}
