using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLine : MonoBehaviour
{
    bool isDrawing = false;
    public bool player2;

    GameObject lineObject;
    [SerializeField]
    GameObject[] lines;

    private void Update()
    {
        if (!player2)
            DrawLine(KeyCode.Comma, 0);
        else
            DrawLine(KeyCode.F, 1);
    }

    void DrawLine(KeyCode keyCode, int _playerNumber)
    {
        if (Input.GetKeyDown(keyCode))
        {
            GameObject line = new GameObject();
            line.AddComponent<LineRenderer>();

            line.GetComponent<LineRenderer>().startWidth = lines[_playerNumber].GetComponent<LineRenderer>().startWidth;
            line.GetComponent<LineRenderer>().material = lines[_playerNumber].GetComponent<LineRenderer>().sharedMaterial;

            line.GetComponent<LineRenderer>().SetPosition(0, new Vector3(transform.position.x, transform.position.y, 0));
            lineObject = line;
            isDrawing = true;
        }

        if (isDrawing)
        {
            lineObject.GetComponent<LineRenderer>().SetPosition(1, new Vector3(transform.position.x, transform.position.y, 0));
        }

        if (Input.GetKeyUp(keyCode))
        {
            isDrawing = false;
        }
    }
}
