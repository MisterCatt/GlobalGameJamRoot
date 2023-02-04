using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FrogPlayer")
        {
            PlayerManager.instance.frogInBase = true;
            PlayerManager.instance.frogCanDraw = true;

            PlayerManager.instance.pointMultiplier = 1;
        }

        if (collision.tag == "BirdPlayer")
        {
            PlayerManager.instance.birdInBase = true;
            PlayerManager.instance.birdCanDraw = true;

            PlayerManager.instance.pointMultiplier = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FrogPlayer")
        {
            PlayerManager.instance.frogInBase = false;
            PlayerManager.instance.frogCanDraw = false;
        }

        if (collision.tag == "BirdPlayer")
        {
            PlayerManager.instance.birdInBase = false;
            PlayerManager.instance.birdCanDraw = false;
        }
    }
}
