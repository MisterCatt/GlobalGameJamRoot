using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_LineSpawning : MonoBehaviour
{
    [SerializeField]
    GameObject selected;
    LineRenderer lr;

    GameObject Triangle;

    public GameObject Point;
    bool isDrawing = false, onSelected = false;

    Player p;

    public int placedPoints = 0;

    float magnitude, maxDistance = 7;
    Vector3 startPos, point_C;

    // Start is called before the first frame update
    void Start()
    {
        p = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlacePoint();
        }

        if (selected)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                selected = null;
                if (isDrawing)
                {
                    isDrawing = false;
                    lr.positionCount--;
                }
            }
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

            selected.GetComponent<LineRenderer>().SetPosition(lr.positionCount - 1, new Vector3(point_C.x, point_C.y, 0));

            placedPoints = lr.positionCount - 1;
        }

        Debug.Log(point_C);
    }

    void PlacePoint()
    {
        if (!selected)
        {
            if (p.canDraw)
            {
                if (p.player2)
                {
                    Triangle = new GameObject("FrogTriangle");
                    Triangle.tag = "Frog";

                    maxDistance = PlayerManager.instance.frogLinePoints;
                }
                else
                {
                    Triangle = new GameObject("BirdTriangle");
                    Triangle.tag = "Bird";

                    maxDistance = PlayerManager.instance.birdLinePoints;
                        
                }
                selected = Instantiate(Point);
                startPos = selected.transform.position = transform.position;

                Vector3 direction = transform.position - startPos;
                magnitude = Mathf.Sqrt(Mathf.Pow(transform.position.x - startPos.x, 2) + Mathf.Pow(transform.position.y - startPos.y, 2));

                if (magnitude > maxDistance)
                {
                    magnitude = maxDistance;
                }

                //Get a new point at your distance from point A
                point_C = startPos + (direction.normalized * magnitude);


                lr = selected.GetComponent<LineRenderer>();
                lr.positionCount++;
                lr.SetPosition(lr.positionCount - 1, point_C);
                lr.positionCount++;
                isDrawing = true;
                selected.transform.parent = Triangle.transform;
            }
        }
        else
        {
            if (placedPoints + 1 > 3 && !onSelected)
                return;

            if(placedPoints == 3)
            {
                if (onSelected)
                {
                    lr.loop= true;
                    selected = null;
                    lr.positionCount--;
                    lr = null;
                    isDrawing= false;
                    placedPoints= 0;
                    return;
                }
            }

            if (!isDrawing)
            {
                startPos = selected.transform.position;
                lr = selected.GetComponent<LineRenderer>();
                lr.positionCount++;
                isDrawing = true;
            }
            else
            {
                GameObject temp = Instantiate(Point);
                temp.transform.position = new Vector3(point_C.x, point_C.y, 0);
                startPos = temp.transform.position;

                lr.SetPosition(lr.positionCount - 1, point_C);
                lr.positionCount++;
                temp.transform.parent = Triangle.transform;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!p.player2)
        {
            if (!selected)
            {
                if (collision.tag == "BirdCheckPoint")
                    selected = collision.gameObject;
            }
            else
            {
                if (collision.gameObject == selected.gameObject)
                {
                    onSelected = true;
                }
            }

            if (collision.tag == "BirdHome")
            {
                p.inHomeBase = true;
                p.canDraw = true;
            }

            if (collision.tag == "BirdWorldBase")
            {
                Debug.Log("KAW");

                p.inHomeBase = true;
            }
        }
        else
        {
            if (!selected)
            {
                if (collision.tag == "FrogCheckPoint")
                    selected = collision.gameObject;
            }
            else
            {
                if (collision.gameObject == selected.gameObject)
                {
                    onSelected = true;
                }
            }

            if (collision.tag == "FrogHome")
            {
                p.inHomeBase = true;
                p.canDraw = true;
            }

            if (collision.tag == "FrogWorldBase")
            {
                Debug.Log("KAW");

                p.inHomeBase = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!p.player2)
        {
            if (collision.tag == "BirdHome")
            {
                p.inHomeBase = false;
                p.canDraw = false;
            }

            if (selected && !isDrawing)
            {
                if (collision.tag == "BirdCheckPoint")
                {
                    selected = null;
                    lr = null;
                }
            }

            if (collision.tag == "BirdWorldBase")
            {
                Debug.Log("KAW?");

                p.inHomeBase = false;
            }
        }
        else
        {
            if (collision.tag == "FrogHome")
            {
                p.inHomeBase = false;
                p.canDraw = false;
            }

            if (selected && !isDrawing)
            {
                if (collision.tag == "FrogCheckPoint")
                {
                    selected = null;
                    lr = null;
                }
            }

            if (collision.tag == "FrogWorldBase")
            {
                Debug.Log("FROG?");

                p.inHomeBase = false;
            }
        }

        //if (collision.gameObject == selected.gameObject && Input.GetKey(KeyCode.C))
        //{
        //    onSelected = false;
        //}

        
    }
}
