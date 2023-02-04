using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public List<GameObject> birdLines;
    public List<GameObject> frogLines;

    public List<GameObject> inactiveLines;

    public static LineManager instance { get; private set; }

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
        birdLines = new List<GameObject>();
        frogLines = new List<GameObject>();

        inactiveLines = new List<GameObject>();

    InvokeRepeating("purgeLines", 0.2f, 0.2f);
    }

    private void FixedUpdate()
    {
        
    }
    void purgeLines()
    {
        
        foreach(GameObject go in inactiveLines)
        {
            Destroy(go);
        }
    }

}
