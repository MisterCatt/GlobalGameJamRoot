using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class P_Move : MonoBehaviour
{

    Rigidbody2D body;
    P_Base p;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        p= GetComponent<P_Base>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * p.speed, vertical * p.speed);
    }
}
