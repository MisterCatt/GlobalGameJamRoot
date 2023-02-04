using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLine : MonoBehaviour
{
    bool isDrawing = false;
    Player pScript;

    float drawDistance = 0,maxDistance, magnitude;

    GameObject lineObject;
    [SerializeField]
    GameObject[] lines, checkPoints;

    Vector3 startPos;
    Vector3 point_C;

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

            

            if (_playerNumber == 0) {
                maxDistance = PlayerManager.instance.birdLinePoints;
                LineManager.instance.birdLines.Add(line);

            }
            else {
                maxDistance = PlayerManager.instance.frogLinePoints;
                LineManager.instance.frogLines.Add(line);
            }

            line.GetComponent<LineRenderer>().SetPosition(0, new Vector3(startPos.x, startPos.y, 0));
            lineObject = line;
            isDrawing = true;
        }

        if (isDrawing)
        {
            //Get the direction of the line
            Vector3 direction = transform.position - startPos;
            magnitude = Mathf.Sqrt(Mathf.Pow(transform.position.x - startPos.x, 2) + Mathf.Pow(transform.position.y - startPos.y, 2));

            if (magnitude > maxDistance)
            {
                magnitude = maxDistance;
            }

            //Get a new point at your distance from point A
            point_C = startPos + (direction.normalized * magnitude);

            if (_playerNumber == 0) {
                    lineObject.GetComponent<LineRenderer>().SetPosition(1, new Vector3(point_C.x, point_C.y, 0));
            }
            else
            {
                lineObject.GetComponent<LineRenderer>().SetPosition(1, new Vector3(point_C.x, point_C.y, 0));
            }
        }

        if (Input.GetKeyUp(keyCode))
        {
            if (magnitude < 1)
            {
                lineObject.SetActive(false);
                LineManager.instance.inactiveLines.Add(lineObject);
                isDrawing = false;
                return;
            }

            if (_playerNumber == 0)
            {
                
                    PlayerManager.instance.birdLinePoints -= magnitude;

                    GameObject temp = Instantiate(checkPoints[0]);
                    temp.transform.parent = null;
                    temp.transform.position = point_C;
            }
            else
            {
                PlayerManager.instance.frogLinePoints -= magnitude;

                    GameObject temp = Instantiate(checkPoints[1]);
                    temp.transform.parent = null;
                    temp.transform.position = point_C;
                
                
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
