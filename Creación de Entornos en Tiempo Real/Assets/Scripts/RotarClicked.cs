using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarClicked : MonoBehaviour
{

    [SerializeField]
    GameObject rotarText;

    [SerializeField]
    GameObject rotatedObject;

    // Condici�n de si el objeto est� siendo rotado
    bool isRotatingObject = false;

    // Condici�n de si el bot�n "Rotar" ha sido pulsado
    bool rotateIsClicked = false;

    /// <summary>
    /// Al hacer clic en el bot�n "Rotar" de la UI, se activa esta funci�n, que pone la condici�n en verdadera
    /// </summary>
    public void RotateObject()
    {
        rotateIsClicked = true;
    } 

    // Update is called once per frame
    private void Update()
    {
        if (rotateIsClicked == true)
        {
            // Si la condici�n es verdadera, se activa la funci�n
            SelectedObject();

            // Si la condici�n es verdadera y el objeto a rotar no es nulo, se activa la funci�n
            if (isRotatingObject == true && rotatedObject != null)
            {
                RotationDirection();
            }
        }
    }

    /// <summary>
    /// Funci�n para poder seleccionar un objeto usando raycast.
    /// </summary>
    private void SelectedObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Si el rayo golpea un objeto que tenga la etiqueta de "Selectable" y se ha hecho clic izquierdo
            if (hit.collider.CompareTag("Selectable") && Input.GetMouseButtonDown(0))
            {
                // Se selecciona el objeto
                rotatedObject = hit.collider.gameObject;

                // La condici�n del objeto en rotaci�n pasa a ser verdadera
                isRotatingObject = true;
            }
        }
    }

    /// <summary>
    /// Funci�n para poder rotar el objeto seleccionado.
    /// </summary>
    private void RotationDirection()
    {
        // Si se pulsa la tecla Q, rota de manera antihoraria
        if (Input.GetKey(KeyCode.Q))
        {
            rotatedObject.transform.Rotate(0.0f, -0.1f, 0.0f);
        }

        // Si se pulsa la tecla E, de manera horaria
        if (Input.GetKey(KeyCode.E))
        {
            rotatedObject.transform.Rotate(0.0f, 0.1f, 0.0f);
        }

        // Si se pulsa el espacio
        if (Input.GetKey(KeyCode.Space))
        {
            // La condici�n del objeto siendo rotado pasa a ser falsa
            isRotatingObject = false;

            // Deja de haber un objeto seleccionado
            rotatedObject = null;

            // La condici�n de si se ha pulsado el bot�n "Rotar" pasa a ser falsa
            rotateIsClicked = false;

            // Animaci�n que se realiza despu�s de pulsar el espacio
            LeanTween.moveY(rotarText.GetComponent<RectTransform>(), -200f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.25f);
        }           
    }
}
