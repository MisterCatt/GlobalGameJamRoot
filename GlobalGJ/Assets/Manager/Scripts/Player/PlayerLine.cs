using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLine : MonoBehaviour
{
    bool isDrawing = false;
    Player pScript;

    float drawDistance = 0,maxDistance;

    GameObject lineObject;
    [SerializeField]
    GameObject[] lines;

    Vector3 startPos;

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

            startPos = transform.position;

            if (_playerNumber == 0)
                maxDistance = PlayerManager.instance.birdLinePoints;
            else
                maxDistance = PlayerManager.instance.frogLinePoints;

            line.GetComponent<LineRenderer>().SetPosition(0, new Vector3(startPos.x, startPos.y, 0));
            lineObject = line;
            isDrawing = true;
        }

        if (isDrawing)
        {
            //Get the direction of the line
            Vector3 direction = transform.position - startPos;
            float magnitude = Mathf.Sqrt(Mathf.Pow(transform.position.x - startPos.x, 2) + Mathf.Pow(transform.position.y - startPos.y, 2));

            Debug.Log(magnitude);

            if (magnitude > maxDistance)
            {
                magnitude = maxDistance;
            }

            //Get a new point at your distance from point A
            Vector3 point_C = startPos + (direction.normalized * magnitude);
            //Draw the line
            Debug.DrawLine(startPos, point_C);

            if (_playerNumber == 0) {
                    lineObject.GetComponent<LineRenderer>().SetPosition(1, new Vector3(point_C.x, point_C.y, 0));
                    PlayerManager.instance.birdLinePoints -= PlayerManager.instance.linePointMultiplier;
            }
            else
            {
                lineObject.GetComponent<LineRenderer>().SetPosition(1, new Vector3(point_C.x, point_C.y, 0));
                PlayerManager.instance.frogLinePoints -= PlayerManager.instance.linePointMultiplier;
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
