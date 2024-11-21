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

    // Condición de si el objeto está siendo rotado
    bool isEscalatingObject = false;

    // Condición de si el botón "Rotar" ha sido pulsado
    bool escalateIsClicked = false;

    private void Awake()
    {
        maxScale = new Vector3(2f, 2f, 2f);
        minScale = new Vector3(0.5f, 0.5f, 0.5f);
        baseScale = new Vector3(1f, 1f,1f);
        scaleChange = new Vector3(0.1f, 0.1f, 0.1f);
    }

    /// <summary>
    /// Al hacer clic en el botón "Escalar" de la UI, se activa esta función, que pone la condición en verdadera
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
                escalatedObject = hit.collider.gameObject;

                // La condición del objeto en rotación pasa a ser verdadera
                isEscalatingObject = true;

                baseScale = escalatedObject.transform.localScale;

                Debug.Log("Base Scale puesta");
            }
        }
    }

    /// <summary>
    /// Función para poder rotar el objeto seleccionado.
    /// </summary>
    private void EscalationDirection()
    {
        // Si el tamaño no es el máximo y se pulsa la flecha hacia arriba, aumenta de tamaño
        if (Input.GetKey(KeyCode.UpArrow))
        {
            baseScale = baseScale + scaleChange;

            Debug.Log("Aumentando");
        }

        // Si el tamaño no es el mínimo y se pulsa la flecha hacia arriba abajo, disminuye de tamaño
        if (Input.GetKey(KeyCode.DownArrow))
        {
            baseScale = baseScale - scaleChange;

            Debug.Log("Disminuyendo");
        }

        // Si se pulsa el espacio
        if (Input.GetMouseButtonDown(1))
        {
            // La condición del objeto siendo rotado pasa a ser falsa
            isEscalatingObject = false;

            // Deja de haber un objeto seleccionado
            escalatedObject = null;

            // La condición de si se ha pulsado el botón "Rotar" pasa a ser falsa
            escalateIsClicked = false;

            // Animación que se realiza después de pulsar el clic derecho
            LeanTween.moveY(escalarText.GetComponent<RectTransform>(), -200f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.25f);

            Debug.Log("Saliendo");
        }
    }
}
