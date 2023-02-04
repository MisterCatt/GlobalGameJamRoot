using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public float getBPS(float tempo)
    {
        return tempo / 60f;
    }
}
