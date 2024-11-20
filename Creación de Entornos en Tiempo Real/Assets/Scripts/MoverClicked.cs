using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverClicked : MonoBehaviour
{
    [SerializeField]
    private GameObject movedObject;

    [SerializeField]

    private bool isMovingObject = false;
    private bool moverIsClicked = false;

    // Se activa al hacer clic en un botón de mover
    public void MoverObject()
    {
        moverIsClicked = true;
    }

    // Actualización por frame
    void Update()
    {
        if (moverIsClicked)
        {
            SelectedObject();

            if (isMovingObject && movedObject != null)
            {
                FollowMouse();

                // Si se hace clic izquierdo, se coloca el objeto
                if (Input.GetMouseButtonDown(0))
                {
                    PlaceObjectAtMouseClick();
                }

            }
        }
    }

    private void SelectedObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Selectable") && Input.GetMouseButtonDown(0) && isMovingObject == false)
            {
                movedObject = hit.collider.gameObject;
                isMovingObject = true;
            }
        }
    }

    // Mueve el objeto seleccionando el movimiento del ratón
    private void FollowMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // El objeto sigue el mouse, a una altura específica
            movedObject.transform.position = new Vector3(hit.point.x, hit.point.y + 2f, hit.point.z);
        }
    }

    // Coloca el objeto en la superficie al hacer clic
    private void PlaceObjectAtMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Suelo"))
            {
                movedObject.transform.position = hit.point; // Coloca el objeto
                isMovingObject = false; // Desactivamos el modo de mover
                movedObject = null; // Limpiamos la referencia
                moverIsClicked = false;
            }
        }
    }
}
