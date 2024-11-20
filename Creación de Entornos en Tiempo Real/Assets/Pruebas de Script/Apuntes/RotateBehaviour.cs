using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBehaviour : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0.0f, -0.1f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0.0f, 0.1f, 0.0f);
        }
    }
}
