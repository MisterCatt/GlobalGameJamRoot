using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FrogPlayer")
        {
            PlayerManager.instance.frogInBase = true;
            PlayerManager.instance.frogCanDraw = true;

            BeatScroller.frogInBasE = true;
        }

        if(collision.tag == "BirdPlayer")
        {
            PlayerManager.instance.birdInBase = true;
            PlayerManager.instance.birdCanDraw = true;

            BeatScroller.birdInBasE = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FrogPlayer")
        {
            PlayerManager.instance.frogInBase = false;
            PlayerManager.instance.frogCanDraw = false;

            BeatScroller.frogInBasE = false;
        }

        if (collision.tag == "BirdPlayer")
        {
            PlayerManager.instance.birdInBase = false;
            PlayerManager.instance.birdCanDraw = false;

            BeatScroller.birdInBasE = false;
        }
    }
}
