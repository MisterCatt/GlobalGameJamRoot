using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControll : MonoBehaviour
{
    GameObject triangle;
    LineRenderer lr;
    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        InvokeRepeating("CheckTriangle", 0.2f,0.2f);   
    }

    void CheckTriangle()
    {
        if (lr.loop)
        {
            SpawnBox();
            CancelInvoke();
        }
    }

    void SpawnBox()
    {
        triangle = new GameObject();
        triangle.name = "HitBox";
        triangle.transform.position = Vector3.zero;
        triangle.tag = "BirdWorldBase";
        PolygonCollider2D collider = triangle.AddComponent<PolygonCollider2D>();
        collider.isTrigger= true;
        
        collider.points = new UnityEngine.Vector2[4] {new Vector2(lr.GetPosition(0).x, lr.GetPosition(0).y), new Vector2(lr.GetPosition(1).x, lr.GetPosition(1).y), new Vector2(lr.GetPosition(2).x, lr.GetPosition(2).y), new Vector2(lr.GetPosition(0).x, lr.GetPosition(0).y) };
    }
}
