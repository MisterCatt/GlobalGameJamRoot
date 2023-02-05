using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{

    LineRenderer lineRenderer;
    List<Vector3> positions;     
    

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        positions = new List<Vector3>();
        positions.Add(Vector3.zero);

    }

    private void Update()
    {
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            positions.Add(new Vector3(mp.x,mp.y,0));
            
            lineRenderer.positionCount++;
            lineRenderer.SetPositions(positions.ToArray());

            Debug.Log("did it");
        }
    }

    
}
