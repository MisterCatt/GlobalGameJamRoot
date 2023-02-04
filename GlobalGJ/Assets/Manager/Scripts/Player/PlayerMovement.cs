using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;

    public bool player2;
    public float speed;

    

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        //cc.Move(transform.position * Time.deltaTime);
    }

    void Move()
    {
        if (Input.GetAxisRaw("P1_X") != 0 || Input.GetAxisRaw("P1_Y") != 0 || Input.GetAxisRaw("P2_X") != 0 || Input.GetAxisRaw("P2_Y") != 0)
        {
            Vector3 move;

            if (!player2)
                move = new Vector3(Input.GetAxisRaw("P1_X"), Input.GetAxisRaw("P1_Y"), 0);
            else
                move = new Vector3(Input.GetAxisRaw("P2_X"), Input.GetAxisRaw("P2_Y"), 0);

            cc.Move(move * Time.deltaTime * speed);
        }
    }
}
