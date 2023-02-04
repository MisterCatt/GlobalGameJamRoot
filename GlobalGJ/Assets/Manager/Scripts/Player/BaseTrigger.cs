using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.transform.tag);
    }
}
