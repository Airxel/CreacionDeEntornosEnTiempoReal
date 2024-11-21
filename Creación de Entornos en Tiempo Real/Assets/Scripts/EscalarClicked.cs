using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EscalarClicked : MonoBehaviour
{

    [SerializeField]
    GameObject escalarText;

    [SerializeField]
    GameObject escalatedObject;

    [SerializeField]
    Vector3 maxScale, minScale, baseScale, scaleChange;

    [SerializeField]
    Vector2 mouseDelta;

    // Condici�n de si el objeto est� siendo rotado
    bool isEscalatingObject = false;

    // Condici�n de si el bot�n "Rotar" ha sido pulsado
    bool escalateIsClicked = false;

    private void Awake()
    {
        maxScale = new Vector3(2f, 2f, 2f);
        minScale = new Vector3(0.5f, 0.5f, 0.5f);
        baseScale = new Vector3(1f, 1f,1f);
        scaleChange = new Vector3(0.1f, 0.1f, 0.1f);
    }

    /// <summary>
    /// Al hacer clic en el bot�n "Escalar" de la UI, se activa esta funci�n, que pone la condici�n en verdadera
    /// </summary>
    public void EscalateObject()
    {
        escalateIsClicked = true;
    }

    // Update is called once per frame
    void Update()
    {
        mouseDelta = Input.mousePosition;

        if (escalateIsClicked == true)
        {
            SelectedObject();

            if (isEscalatingObject == true && escalatedObject != null)
            {
                EscalationDirection();
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
                escalatedObject = hit.collider.gameObject;

                // La condici�n del objeto en rotaci�n pasa a ser verdadera
                isEscalatingObject = true;

                baseScale = escalatedObject.transform.localScale;

                Debug.Log("Base Scale puesta");
            }
        }
    }

    /// <summary>
    /// Funci�n para poder rotar el objeto seleccionado.
    /// </summary>
    private void EscalationDirection()
    {
        // Si el tama�o no es el m�ximo y se pulsa la flecha hacia arriba, aumenta de tama�o
        if (Input.GetKey(KeyCode.UpArrow))
        {
            baseScale = baseScale + scaleChange;

            Debug.Log("Aumentando");
        }

        // Si el tama�o no es el m�nimo y se pulsa la flecha hacia arriba abajo, disminuye de tama�o
        if (Input.GetKey(KeyCode.DownArrow))
        {
            baseScale = baseScale - scaleChange;

            Debug.Log("Disminuyendo");
        }

        // Si se pulsa el espacio
        if (Input.GetMouseButtonDown(1))
        {
            // La condici�n del objeto siendo rotado pasa a ser falsa
            isEscalatingObject = false;

            // Deja de haber un objeto seleccionado
            escalatedObject = null;

            // La condici�n de si se ha pulsado el bot�n "Rotar" pasa a ser falsa
            escalateIsClicked = false;

            // Animaci�n que se realiza despu�s de pulsar el clic derecho
            LeanTween.moveY(escalarText.GetComponent<RectTransform>(), -200f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.25f);

            Debug.Log("Saliendo");
        }
    }
}
