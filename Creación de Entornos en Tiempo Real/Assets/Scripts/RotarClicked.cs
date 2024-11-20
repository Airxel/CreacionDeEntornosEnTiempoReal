using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarClicked : MonoBehaviour
{

    [SerializeField]
    GameObject rotarText;

    [SerializeField]
    GameObject rotatedObject;

    // Condición de si el objeto está siendo rotado
    bool isRotatingObject = false;

    // Condición de si el botón "Rotar" ha sido pulsado
    bool rotateIsClicked = false;

    /// <summary>
    /// Al hacer clic en el botón "Rotar" de la UI, se activa esta función, que pone la condición en verdadera
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
            // Si la condición es verdadera, se activa la función
            SelectedObject();

            // Si la condición es verdadera y el objeto a rotar no es nulo, se activa la función
            if (isRotatingObject == true && rotatedObject != null)
            {
                RotationDirection();
            }
        }
    }

    /// <summary>
    /// Función para poder seleccionar un objeto usando raycast.
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

                // La condición del objeto en rotación pasa a ser verdadera
                isRotatingObject = true;
            }
        }
    }

    /// <summary>
    /// Función para poder rotar el objeto seleccionado.
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
            // La condición del objeto siendo rotado pasa a ser falsa
            isRotatingObject = false;

            // Deja de haber un objeto seleccionado
            rotatedObject = null;

            // La condición de si se ha pulsado el botón "Rotar" pasa a ser falsa
            rotateIsClicked = false;

            // Animación que se realiza después de pulsar el espacio
            LeanTween.moveY(rotarText.GetComponent<RectTransform>(), -200f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.25f);
        }           
    }
}
