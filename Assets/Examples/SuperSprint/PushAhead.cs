using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAhead : MonoBehaviour
{

    public void PushLeft(float distance)
    {
        transform.Translate(-distance, 0f, 0f, Space.World);
    }
}
