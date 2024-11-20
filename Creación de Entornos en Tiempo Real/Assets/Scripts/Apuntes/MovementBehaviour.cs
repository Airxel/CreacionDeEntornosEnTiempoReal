using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] bool isInverted;

    private void Awake()
    {
        if (isInverted == true)
        {
            velocidad = velocidad * -1f;
        }
    }

    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(movX,0.0f, movZ) * velocidad * Time.deltaTime;
        transform.Translate(mov);
    }
}
