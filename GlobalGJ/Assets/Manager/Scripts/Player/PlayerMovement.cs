using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    Player pScript;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed;

    void Start()
    {
        pScript = GetComponent<Player>();
        body = GetComponent<Rigidbody2D>();

        runSpeed = pScript.speed;
    }

    void Update()
    {

        if (!pScript.player2)
        {
            horizontal = Input.GetAxisRaw("P1_X");
            vertical = Input.GetAxisRaw("P1_Y");

            if(horizontal != 0 || vertical != 0)
            {
                BeatScroller.birdWalking = true;

                if (horizontal > 0)
                {
                    if(transform.localScale.x > 0)
                    {
                        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    }
                    else
                    {
                        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    }
                }
                else
                {
                    if (transform.localScale.x < 0)
                    {
                        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    }
                    else
                    {
                        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    }
                }
            }
            else
            {
                BeatScroller.birdWalking = false;
            }
        }
        else
        {
            horizontal = Input.GetAxisRaw("P2_X"); 
            vertical = Input.GetAxisRaw("P2_Y");

            if (horizontal != 0 || vertical != 0)
            {
                BeatScroller.frogWalking = true;

                if (horizontal > 0)
                {
                    if (transform.localScale.x > 0)
                    {
                        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    }
                    else
                    {
                        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    }
                }
                else
                {
                    if (transform.localScale.x < 0)
                    {
                        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    }
                    else
                    {
                        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    }
                }
            }
            else
            {
                BeatScroller.frogWalking = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) 
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * pScript.speed, vertical * pScript.speed);
    }
}
