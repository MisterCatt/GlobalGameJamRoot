using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrigger : MonoBehaviour
{
    //private void FixedUpdate()
    //{
    //    distanceToCoin = Vector3.Distance(coin[i].transform.position, player.transform.position);

    //    if (distanceToCoin < distanceToCollectCoin)
    //        Debug.Log("Near Coin");
    //}

    float distance;

    private void FixedUpdate()
    {
        if (transform.tag == "BirdHome")
        {
            foreach (GameObject g in LineManager.instance.frogLines)
            {
                if (g != null)
                {
                    distance = Vector3.Distance(g.transform.position, transform.position);
                    Debug.Log(distance);
                    if (distance < 0.5f)
                    {
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }
        if(transform.tag == "FrogHome")
        {
            foreach (GameObject g in LineManager.instance.birdLines)
            {
                if (g != null)
                {
                    distance = Vector3.Distance(g.transform.position, transform.position);
                    if (distance < 0.5f)
                    {
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }
    }


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

    private void OnDestroy()
    {
        GameManager.instance.UpdateState(GameState.GAMEOVER);
    }
}
