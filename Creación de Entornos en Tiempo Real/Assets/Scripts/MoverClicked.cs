using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverClicked : MonoBehaviour
{
    [SerializeField]
    GameObject moverText;
    
    [SerializeField]
    GameObject movedObject;

    // Condición de si el objeto está en movimiento
    bool isMovingObject = false;

    // Condición de si el botón "Mover" ha sido pulsado
    bool moverIsClicked = false;

    /// <summary>
    /// Al hacer clic en el botón "Mover" de la UI, se activa esta función, que pone la condición en verdadera
    /// </summary>
    public void MoverObject()
    {
        moverIsClicked = true;
    }

    // Update is called once per frame
    private void Update()
    {
        // Si la condición es verdadera, se activa la función
        if (moverIsClicked == true)
        {
            SelectedObject();

            // Si la condición es verdadera y el objeto a mover no es nulo, se activa la función
            if (isMovingObject == true && movedObject != null)
            {
                FollowMouse();

                // Si se hace clic izquierdo, se activa la función
                if (Input.GetMouseButtonDown(0))
                {
                    PlaceObjectAtMouseClick();
                }

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
                movedObject = hit.collider.gameObject;

                // La condición del objeto en movimiento pasa a ser verdadera
                isMovingObject = true;
            }
        }
    }

    /// <summary>
    /// Función para que el objeto seleccionado siga al ratón usando raycast.
    /// </summary>
    private void FollowMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // El objeto sigue al ratón a una distancia algo alejada porque el raycast estaba afectando al propio objeto al moverse,
            // ya que el ratón estaba sobre el objeto en algunos casos
            movedObject.transform.position = new Vector3(hit.point.x, hit.point.y + 2f, hit.point.z);
        }
    }

    /// <summary>
    /// Función para poder colocar el objeto seleccionado, usando raycast, en alguna superficie concreta al hacer clic izquierdo
    /// </summary>
    private void PlaceObjectAtMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // La superficie tiene que tener la etiqueta de "Suelo" o el objeto no se puede colocar
            if (hit.collider.CompareTag("Suelo"))
            {
                // Se coloca el objeto donde el rayo golpee al hacer clic
                movedObject.transform.position = hit.point;

                // La condición del objeto en movimiento pasa a ser falsa
                isMovingObject = false;

                // Deja de haber un objeto seleccionado
                movedObject = null;

                // La condición de si se ha pulsado el botón "Mover" pasa a ser falsa
                moverIsClicked = false;

                // Animación que se realiza después de colocar el objeto
                LeanTween.moveY(moverText.GetComponent<RectTransform>(), -200f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.25f);
            }
        }
    }
}
