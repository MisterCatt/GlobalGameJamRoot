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
        // Gives a value between -1 and 1

        if (!pScript.player2)
        {
            horizontal = Input.GetAxisRaw("P1_X"); // -1 is left
            vertical = Input.GetAxisRaw("P1_Y"); // -1 is down
        }
        else
        {
            horizontal = Input.GetAxisRaw("P2_X"); // -1 is left
            vertical = Input.GetAxisRaw("P2_Y");
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * pScript.speed, vertical * pScript.speed);
    }
}
