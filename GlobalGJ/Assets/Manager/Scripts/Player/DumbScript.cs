using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Destroy(LineManager.instance.birdLines[0].gameObject);
        }
    }
}
