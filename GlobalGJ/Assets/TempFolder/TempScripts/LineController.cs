using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    LineRenderer lr;
    List<Transform> points;

    [SerializeField]
    private GameObject pointObject;

    GameObject selected;

    // Start is called before the first frame update
    void Start()
    {
        points = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (!selected)
            {
                selected = Instantiate(pointObject);
                selected.transform.position = position;

                lr = selected.GetComponent<LineRenderer>();

                points.Add(pointObject.transform);

                lr.positionCount++;
            }
            else
            {
                pointObject = Instantiate(pointObject);
                selected.transform.position=position;

                points.Add(pointObject.transform);
                lr.positionCount++;
            }
        }

        if(selected && Input.GetKeyDown(KeyCode.C))
        {
            selected = null;
        }

        for(int i = 0; i < points.Count; i++)
        {
             lr.SetPosition(i, points[i].position);
        }
    }

    void AddPoints(Transform point)
    {

    }
}
